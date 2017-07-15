using EFDomain.RedisCache;
using EFDomain.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        RedisProduct redis = new RedisProduct();
        RedisOrderMessage orderRedis = new RedisOrderMessage();
        int orderNo = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            var orderCount = Convert.ToInt32(txt_OrderCount.Text);
            var productId = Convert.ToInt32(txt_ProductId.Text);

            var productCount = Convert.ToInt32(txt_ProductCount.Text);

            for (int i = 0; i < orderCount; i++)
            {
                RedisOrderModel cacheOrder = new RedisOrderModel()
                {
                    Count = productCount,
                    OrderNo = (orderNo += 1).ToString(),
                    ProductId = productId
                };
                orderRedis.Push(cacheOrder);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Pid = Convert.ToInt32(txt_Count.Text);
            var count = Convert.ToInt32(txt_Store.Text);

            redis.UpdateCache(Pid.ToString(), new CacheProduct() { Count=count,ProductId=Pid});

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var obj = redis.Get(txt_ProductId.Text);
            if (obj!=null)
            {
                lbl_StoreCount.Text = "库存数:" + obj.Count;
            }
        }
    }
}
