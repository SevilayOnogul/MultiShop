using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        // RabbitMQ bağlantı ayarlarını tutan fabrika nesnesi
        private readonly ConnectionFactory _connectionFactory;

        public MessageController()
        {
            // Bağlantı fabrikasını localhost (kendi bilgisayarımız) üzerinden yapılandırıyoruz
            _connectionFactory = new ConnectionFactory { HostName = "localhost" };
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            // RabbitMQ sunucusuna asenkron bir bağlantı açıyoruz
            using var connection = await _connectionFactory.CreateConnectionAsync();

            // Veri iletimi için bir kanal (channel) oluşturuyoruz
            using var channel = await connection.CreateChannelAsync();

            // Mesajların toplanacağı "Kuyruk1" adında bir kuyruk tanımlıyoruz
            // durable:false -> Mesajlar sadece bellekte tutulur, sunucu kapanırsa silinir.
            await channel.QueueDeclareAsync("Kuyruk1", false, false, false, null);

            // Gönderilecek metin mesajı
            var messageContent = "Merhaba bugün hava çok sıcak";

            // RabbitMQ sadece byte dizilerini kabul eder, metni byte'a çeviriyoruz
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            // Mesajı herhangi bir exchange (dağıtıcı) kullanmadan doğrudan "Kuyruk1"e gönderiyoruz
            await channel.BasicPublishAsync(exchange: "", routingKey: "Kuyruk1", body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            // Okuma işlemi için yeni bir bağlantı ve kanal açıyoruz
            using var connection = await _connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // Okuyacağımız kuyruğun varlığından emin oluyoruz
            await channel.QueueDeclareAsync("Kuyruk1", false, false, false, null);

            // Kuyruktan en öndeki tek bir mesajı çekiyoruz
            // autoAck: false -> "Mesajı aldım" onayını manuel vereceğimizi belirtiyoruz
            var result = await channel.BasicGetAsync("Kuyruk1", autoAck: false);

            if (result == null)
            {
                return Ok("Kuyrukta okunacak mesaj bulunamadı.");
            }

            // Byte dizisi olarak gelen mesaj gövdesini tekrar metne (string) çeviriyoruz
            var messageBody = result.Body.ToArray();
            var message = Encoding.UTF8.GetString(messageBody);

            // Mesajın başarıyla işlendiğini RabbitMQ'ya bildiriyoruz (Ack). 
            // Bu komutla beraber mesaj kuyruktan tamamen silinir.
            await channel.BasicAckAsync(deliveryTag: result.DeliveryTag, multiple: false);

            return Ok(message);
        }
    }
}