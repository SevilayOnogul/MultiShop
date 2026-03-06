namespace MultiShop.RapidApiWebUI.Models
{
    public class ECommerceViewModel
    {
      
            public string status { get; set; }
            public string request_id { get; set; }
            public Data data { get; set; }
        

        public class Data
        {
            public Product[] products { get; set; }
            public object[] sponsored_products { get; set; }
            public Filter[] filters { get; set; }
        }

        public class Product
        {
            public string product_id { get; set; }
            public string product_title { get; set; }
            public string product_description { get; set; }
            public string[] product_photos { get; set; }
            public Product_Videos[] product_videos { get; set; }
            public Product_Attributes product_attributes { get; set; }
            public float? product_rating { get; set; }
            public string product_page_url { get; set; }
            public int? product_num_reviews { get; set; }
            public int? product_num_offers { get; set; }
            public object typical_price_range { get; set; }
            public Current_Product_Variant_Properties current_product_variant_properties { get; set; }
            public Product_Variants product_variants { get; set; }
            public Reviews_Insights reviews_insights { get; set; }
            public Offer offer { get; set; }
        }

        public class Product_Attributes
        {
            public string ConnectivityType { get; set; }
            public string Interface { get; set; }
            public string Compatibility { get; set; }
            public string WirelessTechnology { get; set; }
            public string MultiDeviceConnectivity { get; set; }
            public string SupportedDevices { get; set; }
            public string Range { get; set; }
            public string USBReceiver { get; set; }
            public string NumberofButtons { get; set; }
            public string ProgrammableButtons { get; set; }
            public string ScrollType { get; set; }
            public string GestureSupport { get; set; }
            public string FunctionalityHighlights { get; set; }
            public string TrackingMethod { get; set; }
            public string TrackingPrecision { get; set; }
            public string TrackingSurfaceType { get; set; }
            public string BatteryLife { get; set; }
            public string PowerSource { get; set; }
            public string BatteryType { get; set; }
            public string ChargingType { get; set; }
            public string PowerIndicator { get; set; }
            public string Weight { get; set; }
            public string Width { get; set; }
            public string Depth { get; set; }
            public string Height { get; set; }
            public string SensorType { get; set; }
            public string PollingRate { get; set; }
            public string Switches { get; set; }
            public string FeetMaterial { get; set; }
            public string TopUseCases { get; set; }
            public string TypicalUsers { get; set; }
            public string SkillLevel { get; set; }
            public string MouseType { get; set; }
            public string Subtype { get; set; }
            public string ErgonomicSize { get; set; }
            public string VerticalDesign { get; set; }
            public string Support { get; set; }
            public string WristRest { get; set; }
            public string ErgonomicHighlights { get; set; }
            public string HandOrientation { get; set; }
            public string Shape { get; set; }
            public string DesignHighlights { get; set; }
            public string GripType { get; set; }
            public string Lighting { get; set; }
            public string Material { get; set; }
            public string Finish { get; set; }
            public string Sensitivity { get; set; }
            public string Acceleration { get; set; }
            public string TrackingSpeed { get; set; }
            public string LiftOffDistance { get; set; }
            public string ProfileStorage { get; set; }
            public string BuildQuality { get; set; }
            public string DustResistance { get; set; }
            public string MultiDevicePairing { get; set; }
            public string SilentClicks { get; set; }
            public string AdjustableWeight { get; set; }
            public string AccessoryType { get; set; }
            public string AgeRange { get; set; }
            public string CableLength { get; set; }
        }

        public class Current_Product_Variant_Properties
        {
            public string Colour { get; set; }
        }

        public class Product_Variants
        {
            public Colour[] Colour { get; set; }
        }

        public class Colour
        {
            public string name { get; set; }
            public string thumbnail { get; set; }
            public string product_id { get; set; }
        }

        public class Reviews_Insights
        {
        }

        public class Offer
        {
            public string offer_id { get; set; }
            public string offer_title { get; set; }
            public string offer_page_url { get; set; }
            public string price { get; set; }
            public object original_price { get; set; }
            public bool on_sale { get; set; }
            public string shipping { get; set; }
            public string product_condition { get; set; }
            public string store_name { get; set; }
            public string store_rating { get; set; }
            public int store_review_count { get; set; }
            public string store_reviews_page_url { get; set; }
            public string store_favicon { get; set; }
            public object payment_methods { get; set; }
            public string returns { get; set; }
            public string offer_badge { get; set; }
        }

        public class Product_Videos
        {
            public string title { get; set; }
            public string url { get; set; }
            public string source { get; set; }
            public string publisher { get; set; }
            public string thumbnail { get; set; }
            public string preview_url { get; set; }
            public int duration_ms { get; set; }
        }

        public class Filter
        {
            public string title { get; set; }
            public bool multivalue { get; set; }
            public Value[] values { get; set; }
        }

        public class Value
        {
            public string title { get; set; }
            public string q { get; set; }
            public string shoprs { get; set; }
        }

    }
}
