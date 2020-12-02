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
            //string query = @"SELECT LEFT(sBarCode, 8) AS sku, LEFT(sBarCode, 10) AS Barcode, sBarCode FROM " + "buy" + year + month + "";
            string zeilsQuery = @"SELECT LEFT(sBarCode, 8) AS sku, LEFT(sBarCode, 10) AS Barcode, sBarCode FROM BuyCentral";
            DataTable zeilsDataTable = dataManage.ZeilsGetDataTable(zeilsQuery);

            foreach (DataRow row in zeilsDataTable.Rows)
            {
                var SKU = row["sku"].ToString();
                var Barcode = row["Barcode"].ToString();
                var sBarCode = row["sBarCode"].ToString();

                string eZeilsQuery = @"SELECT Id, Quantity FROM ProductAttributeValue WHERE BarCode = '" + Barcode + "'";
                DataTable eZeilsDataTable = dataManage.EZeilsGetDataTable(eZeilsQuery);
                
                if(eZeilsDataTable.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(eZeilsDataTable.Rows[0][0]);
                    string zeilsQuery2 = string.Format(@"SELECT (SELECT ISNULL(SUM(balQty),0) FROM BuyCentral WHERE sBarCode = '{0}') + (SELECT ISNULL(SUM(balQty),0) FROM " + "buy" + year + month + " WHERE sBarCode = '{1}') AS StockQuantity", sBarCode, sBarCode);
                    DataTable data = dataManage.ZeilsGetDataTable(zeilsQuery2);

                    var quantity = Convert.ToInt32(data.Rows[0][0]);

                    string eZeilsQuery2 = @"UPDATE ProductAttributeValue SET Quantity = " + quantity + " WHERE Id = " + id + "";
                    if (dataManage.EZeilsExecute(eZeilsQuery2))
                    {
                        continue;
                    }
                }
                
                // using nopCommerce api
                //using (var client = new HttpClient())
                //{
                //    var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2MDU2MDY1NzQsImV4cCI6MTkyMDk2NjU3NCwiaXNzIjoiaHR0cDovL2V6ZWlscy5jb20iLCJhdWQiOlsiaHR0cDovL2V6ZWlscy5jb20vcmVzb3VyY2VzIiwibm9wX2FwaSJdLCJjbGllbnRfaWQiOiI1YWM2ZDVkNS03Njk3LTQzYmUtYmYyNC0yMmU5MTM2NWUyZjMiLCJzdWIiOiI1YWM2ZDVkNS03Njk3LTQzYmUtYmYyNC0yMmU5MTM2NWUyZjMiLCJhdXRoX3RpbWUiOjE2MDU2MDY1NzMsImlkcCI6ImxvY2FsIiwic2NvcGUiOlsibm9wX2FwaSIsIm9mZmxpbmVfYWNjZXNzIl0sImFtciI6WyJwd2QiXX0.hnWuHiTNtJiZJ3eVf8PWfkmxPOF34lsiYkSyO2sbb-q5PuNoMfBCtT5f5PFUIcuEGoKzpv2rGYM2ET6w4Ia3zuXP9i0KdFUpDl9Ksna1EjKWjvBz5sajoeYpTmQhBjxJ8EB-aZx_InVvoa47aQp5cMTJHs7BQHADiq6ClF2x02Zz4u10cdwHr5ZmEeSrxLjVmlXRACwmGUh8efHgrayu6bXpcSQpZpiMv8XT3SdsvjpK4Ninvu-dSMtf5JIYqo20fGZrSXmLUFUf66ev64_cxViuPXLnoFSGEL-jS5Ji8yPX-qezh6DpudymRsFy1KccKm1Mb9I-EA4oaapz3qOc1A";
                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    HttpResponseMessage response = client.GetAsync("http://ezeils.com/api/products").GetAwaiter().GetResult();

                //    if (response.IsSuccessStatusCode)
                //    {
                //        var curlRequestContent = response.Content.ReadAsStringAsync();
                //        curlRequestContent.Wait();
                //        var contentResult = curlRequestContent.Result;

                //        Root targetData = JsonConvert.DeserializeObject<Root>(contentResult);

                //        foreach (var da in targetData.products)
                //        {
                //            if(da.sku != null)
                //            {
                //                string ezeilsSKU = da.sku.ToString();

                //                if (zeilsSKU == ezeilsSKU)
                //                {
                //                    string query2 = string.Format(@"SELECT (SELECT SUM(balQty) FROM BuyCentral WHERE sBarCode = '{0}') + (SELECT SUM(balQty) FROM buy202011 WHERE sBarCode = '{1}') AS StockQuantity", sBarCode, sBarCode);
                //                    DataTable data = dataManage.ZeilsGetDataTable(query2);

                //                    RootUpdate updateStock = new RootUpdate();
                //                    updateStock.product = new UpdateProduct();
                //                    updateStock.product.stock_quantity = Convert.ToInt32(data.Rows[0][0]);
                //                    var serializedData = JsonConvert.SerializeObject(updateStock);
                //                    var content = new StringContent(serializedData, Encoding.UTF8, "application/json");

                //                    var response2 = client.PutAsync("http://ezeils.com/api/products/" + da.id, content).GetAwaiter().GetResult();

                //                    if (response2.StatusCode == HttpStatusCode.OK)
                //                    {
                //                        continue;
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
            }
        }
    }
}
