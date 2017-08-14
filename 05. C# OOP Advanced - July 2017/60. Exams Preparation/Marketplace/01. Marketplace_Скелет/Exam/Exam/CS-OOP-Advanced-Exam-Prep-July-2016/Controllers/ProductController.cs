using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle;
using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Controller;
using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Request;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Controllers
{
    [Controller]
    public class ProductController
    {
        [RequestMapping(value: "/product/{size}/{name}/{type}", method: RequestMethod.ADD)]
        public void AddProduct(
           [UriParameter("size")] int size,
           [UriParameter("name")] string name,
           [UriParameter("type")] string type)
        {
            Console.WriteLine("size: " + size + "name: " + name + "type: " + type);
        }
    }
}
