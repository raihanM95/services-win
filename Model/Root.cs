using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeilsData.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class LocalizedName
    {
        public int language_id { get; set; }
        public string localized_name { get; set; }
    }

    public class Image
    {
        public int id { get; set; }
        public int picture_id { get; set; }
        public int position { get; set; }
        public string src { get; set; }
        public object attachment { get; set; }
    }

    public class AttributeValue
    {
        public int type_id { get; set; }
        public int associated_product_id { get; set; }
        public string name { get; set; }
        public string color_squares_rgb { get; set; }
        public object image_squares_image { get; set; }
        public double price_adjustment { get; set; }
        public double weight_adjustment { get; set; }
        public double cost { get; set; }
        public int quantity { get; set; }
        public bool is_pre_selected { get; set; }
        public int display_order { get; set; }
        public object product_image_id { get; set; }
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Attribute
    {
        public int product_attribute_id { get; set; }
        public string product_attribute_name { get; set; }
        public object text_prompt { get; set; }
        public bool is_required { get; set; }
        public int attribute_control_type_id { get; set; }
        public int display_order { get; set; }
        public object default_value { get; set; }
        public string attribute_control_type_name { get; set; }
        public List<AttributeValue> attribute_values { get; set; }
        public int id { get; set; }
    }

    public class Product
    {
        public bool visible_individually { get; set; }
        public string name { get; set; }
        public List<LocalizedName> localized_names { get; set; }
        public object short_description { get; set; }
        public string full_description { get; set; }
        public bool show_on_home_page { get; set; }
        public object meta_keywords { get; set; }
        public object meta_description { get; set; }
        public object meta_title { get; set; }
        public bool allow_customer_reviews { get; set; }
        public int approved_rating_sum { get; set; }
        public int not_approved_rating_sum { get; set; }
        public int approved_total_reviews { get; set; }
        public int not_approved_total_reviews { get; set; }
        public object sku { get; set; }
        public object manufacturer_part_number { get; set; }
        public object gtin { get; set; }
        public bool is_gift_card { get; set; }
        public bool require_other_products { get; set; }
        public bool automatically_add_required_products { get; set; }
        public bool is_download { get; set; }
        public bool unlimited_downloads { get; set; }
        public int max_number_of_downloads { get; set; }
        public object download_expiration_days { get; set; }
        public bool has_sample_download { get; set; }
        public bool has_user_agreement { get; set; }
        public bool is_recurring { get; set; }
        public int recurring_cycle_length { get; set; }
        public int recurring_total_cycles { get; set; }
        public bool is_rental { get; set; }
        public int rental_price_length { get; set; }
        public bool is_ship_enabled { get; set; }
        public bool is_free_shipping { get; set; }
        public bool ship_separately { get; set; }
        public double additional_shipping_charge { get; set; }
        public bool is_tax_exempt { get; set; }
        public bool is_telecommunications_or_broadcasting_or_electronic_services { get; set; }
        public bool use_multiple_warehouses { get; set; }
        public int manage_inventory_method_id { get; set; }
        public int stock_quantity { get; set; }
        public bool display_stock_availability { get; set; }
        public bool display_stock_quantity { get; set; }
        public int min_stock_quantity { get; set; }
        public int notify_admin_for_quantity_below { get; set; }
        public bool allow_back_in_stock_subscriptions { get; set; }
        public int order_minimum_quantity { get; set; }
        public int order_maximum_quantity { get; set; }
        public object allowed_quantities { get; set; }
        public bool allow_adding_only_existing_attribute_combinations { get; set; }
        public bool disable_buy_button { get; set; }
        public bool disable_wishlist_button { get; set; }
        public bool available_for_pre_order { get; set; }
        public object pre_order_availability_start_date_time_utc { get; set; }
        public bool call_for_price { get; set; }
        public double price { get; set; }
        public double old_price { get; set; }
        public double product_cost { get; set; }
        public object special_price { get; set; }
        public object special_price_start_date_time_utc { get; set; }
        public object special_price_end_date_time_utc { get; set; }
        public bool customer_enters_price { get; set; }
        public double minimum_customer_entered_price { get; set; }
        public double maximum_customer_entered_price { get; set; }
        public bool baseprice_enabled { get; set; }
        public double baseprice_amount { get; set; }
        public double baseprice_base_amount { get; set; }
        public bool has_tier_prices { get; set; }
        public bool has_discounts_applied { get; set; }
        public double weight { get; set; }
        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public object available_start_date_time_utc { get; set; }
        public object available_end_date_time_utc { get; set; }
        public int display_order { get; set; }
        public bool published { get; set; }
        public bool deleted { get; set; }
        public DateTime created_on_utc { get; set; }
        public DateTime updated_on_utc { get; set; }
        public string product_type { get; set; }
        public int parent_grouped_product_id { get; set; }
        public List<object> role_ids { get; set; }
        public List<object> discount_ids { get; set; }
        public List<object> store_ids { get; set; }
        public List<int> manufacturer_ids { get; set; }
        public List<Image> images { get; set; }
        public List<Attribute> attributes { get; set; }
        public List<object> product_attribute_combinations { get; set; }
        public List<object> product_specification_attributes { get; set; }
        public List<object> associated_product_ids { get; set; }
        public List<string> tags { get; set; }
        public int vendor_id { get; set; }
        public string se_name { get; set; }
        public int id { get; set; }
    }

    public class Root
    {
        public List<Product> products { get; set; }
        public Product product { get; set; }
    }
}
