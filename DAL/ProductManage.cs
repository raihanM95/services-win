using EzeilsData.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EzeilsData.DAL
{
    public class ProductManage
    {
        public void UpdateProduct()
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");

            DataManage dataManage = new DataManage();
            string query = @"SELECT LEFT(sBarCode, 8) AS sku, sBarCode FROM " + "buy" + year + month + "";
            DataTable dataTable = dataManage.GetDataTable(query);

            foreach (DataRow row in dataTable.Rows)
            {
                var zeilsSKU = row["sku"].ToString();
                var sBarCode = row["sBarCode"].ToString();

                using (var client = new HttpClient())
                {
                    var token = ""; // enter nopCommerce API token
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("http://ezeils.com/api/products").GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var curlRequestContent = response.Content.ReadAsStringAsync();
                        curlRequestContent.Wait();
                        var contentResult = curlRequestContent.Result;

                        Root targetData = JsonConvert.DeserializeObject<Root>(contentResult);

                        foreach (var da in targetData.products)
                        {
                            if(da.sku != null)
                            {
                                string ezeilsSKU = da.sku.ToString();

                                if (zeilsSKU == ezeilsSKU)
                                {
                                    string query2 = string.Format(@"SELECT (SELECT SUM(balQty) FROM BuyCentral WHERE sBarCode = '{0}') + (SELECT SUM(balQty) FROM buy202011 WHERE sBarCode = '{1}') AS StockQuantity", sBarCode, sBarCode);
                                    DataTable data = dataManage.GetDataTable(query2);

                                    RootUpdate updateStock = new RootUpdate();
                                    updateStock.product = new UpdateProduct();
                                    updateStock.product.stock_quantity = Convert.ToInt32(data.Rows[0][0]);
                                    var serializedData = JsonConvert.SerializeObject(updateStock);
                                    var content = new StringContent(serializedData, Encoding.UTF8, "application/json");

                                    var response2 = client.PutAsync("http://ezeils.com/api/products/" + da.id, content).GetAwaiter().GetResult();

                                    if (response2.StatusCode == HttpStatusCode.OK)
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
