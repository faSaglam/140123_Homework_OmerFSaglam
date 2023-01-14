using _140123_Homework.Models;
using _140123_Homework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace _140123_Homework.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NorthwndContext _northwndContext;
        public EmployeeController(NorthwndContext northwndContext)
        {
            _northwndContext = northwndContext;
        }

        public IActionResult Index()
        {
            var employee = _northwndContext.Employees.ToList();


            
            return View(employee);
      
      
        }
        public IActionResult Orders(int EmployeeId)
        {

            var orders = _northwndContext.Orders.Where(x => x.EmployeeId == EmployeeId).ToList();

            return View(orders);
        }
        public IActionResult OrderDetail(int OrderId)
        {
         
            var orderDetail = _northwndContext.OrderDetails.Where(x => x.OrderId == OrderId).Include(x=>x.Product).ToList();



            return View(orderDetail);
        }
        public IActionResult Product(int OrderId)
        
        {
            var x = _northwndContext.OrderDetails.Include(x => x.Product).Where(x=>x.OrderId == OrderId).Select(x => x.Product).ToList();
            
            return View(x);
                }
    
        public IActionResult Territory(int EmployeeId)
        {


            #region UnsuccesfullyTryings
            //List<ICollection<Territory>> y = _northwndContext.Employees.Include(x => x.Territories).Where(x=>x.EmployeeId == EmployeeId).Select(x=>x.Territories).ToList();
            //var y = _northwndContext.Employees.Include(x => x.Territories).Select(x=>x.Territories);
            //var y = _northwndContext.Employees.Include(x => x.Territories).SingleOrDefault(x => x.EmployeeId == EmployeeId);
            //var y = _northwndContext.Territories.Include(t => t.Employees.Where(x => x.EmployeeId==EmployeeId)).ToList();
            //var y = _northwndContext.Territories.Include(x => x.Employees.Select(t => t.EmployeeId == EmployeeId)).ToList();
            //var y = _northwndContext.Employees.Include(x => x.Territories).Select(x=>x.Territories);
            //var y = _northwndContext.Employees.Where(e=>e.EmployeeId==EmployeeId).Select(x=>x.Territories).ToList();
            //var x = _northwndContext.Employees.Include(x=>x.Territories).ToList().Where(x => x.EmployeeId == EmployeeId).Select(x=>x.Territories).First();//data dönmüyor
            //var y = _northwndContext.Employees.Include(x => x.Territories).ToList().Where(x => x.EmployeeId == EmployeeId).Select(x => x.Territories).FirstOrDefault();//data dönmüyor
            //var z = _northwndContext.Employees.Include(x => x.Territories).Where(x => x.EmployeeId == EmployeeId).Select(x => x.Territories).FirstOrDefault();//data dönmüyor
            //var y = _northwndContext.Employees.Include(x => x.Territories).SingleOrDefault(x => x.EmployeeId == EmployeeId).Territories;
            //var y= _northwndContext.Territories.Include(x=>x.Employees.Where(x=>x.EmployeeId == EmployeeId)).ToList();
            //var y = _northwndContext.Employees.Include(x => x.Territories).SingleOrDefault(x => x.EmployeeId == EmployeeId).Territories;
            //var territory = _northwndContext.Employees.Where(x => x.EmployeeId == EmployeeId).Include(x=>x.Territories).Select(x => x.Territories).FirstOrDefault();   
            //var y = from e in _northwndContext.Employees
            //        from t in e.Territories where e.EmployeeId == EmployeeId
            //        select t;
            //var y = _northwndContext.Employees.Where(e => e.EmployeeId == EmployeeId).SelectMany(e => e.Territories).Take(10).ToList();
            //var y = from t in _northwndContext.Territories
            //        where t.Employees.Any(t => t.EmployeeId == EmployeeId)
            //        select t; // EmployeeeTerritory
            //var y = from t in _northwndContext.Territories
            //        from e in t.Employees.Where(e=>e.EmployeeId == EmployeeId)
            //        select t; //EmployeeeTerritory
            //var y = _northwndContext.Employees.Where(x => x.EmployeeId == EmployeeId).SelectMany(x => x.Territories); //EmployeeeTerritory
            //var y = from e in _northwndContext.Employees
            //        where e.EmployeeId == EmployeeId
            //        select e.Territories;//EmployeeeTerritory
            //var y = from x in _northwndContext.Employees
            //        group x by x.EmployeeId into g
            //        select new
            //        {
            //            EmployeeId = g.Key,
            //            Territory = g.Count()
            //        };hiç alakası yok
            //var y = from t in _northwndContext.Territories
            //        from e in t.Employees.Where(x => x.EmployeeId == EmployeeId)
            //        join x in _northwndContext.Employees on e.EmployeeId equals x.EmployeeId
            //        into empTer

            //        select empTer; //Employee döndü


            //var y = from employee in _northwndContext.Employees
            //        join territoy in _northwndContext.Territories equals empTer into xy
            //        select new
            //        {
            //            territoryExecutive = employee.FirstName
            //            territories = xy
            //        };
            //var person = (from p in db.Employees
            //              where p.SalesPerson.SalesTerritory.CountryRegionCode == "CA"
            //              select new
            //              {
            //                  ID = p.BusinessEntityID,
            //                  FirstName = p.Person.FirstName,
            //                  MiddleName = p.Person.MiddleName,
            //                  LastName = p.Person.LastName,
            //                  Region = p.SalesPerson.SalesTerritory.CountryRegionCode
            //              }).ToList();
            //var y = _northwndContext.Employees.Where(x => x.EmployeeId == EmployeeId).SelectMany(x => x.Territories).ToList();
            //var y = from e in _northwndContext.Employees
            //        from t in _northwndContext.Territories
            //        select new {
            //            e.EmployeeId, t.TerritoryId, t.TerritoryDescription
            //        };

            //var y = from e in _northwndContext.Territories
            //        join t in _northwndContext.EmployeeTerritories.Where(q => q.EmployeeId == EmployeeId).DefaultIfEmpty()
            //        select new Territory {
            //            TerritoryDescription = e.TerritoryDescription,


            //        };
            //from c in context.Contacts
            //where c.FirstName == "Robert"
            //let ContactName = new { c.Title, c.LastName, c.FirstName }
            //select ContactName
            //var ter = from t in _northwndContext.Employees
            //          select t.Territories;

            //EmployeeTerritory

            //            select e2.TerritoryID
            //from Employees e1
            //INNER JOIN EmployeeTerritories e2 on EmployeeID

            //SELECT TerritoryDescription
            //FROM(select e2.TerritoryID
            //from Employees e1
            //INNER JOIN EmployeeTerritories e2 on EmployeeID
            //)

            //from p in data.Person
            //select new MyModel
            //{
            //    carList = (from pc in data.Persons_Cars
            //               join c in data.car on pc.id_car equals c.ID
            //               where pc.ID_Person == p.ID
            //               select c).ToList()
            //};
            // person = employeee
            // personcar = employeeeterritory
            //car = employeee



            //context.People.Where(p => p.PersonID == pID).Include(c => c.Cars).FirstOrDefault();

            //var q = _northwndContext.Employees.Where(x=>x.EmployeeId == EmployeeId).Include(t => t.Territories).First();


            //var y = from t in _northwndContext.Employees
            //        select new 

            //        {
            //            terList = t.Territories.Select(x => x.TerritoryDescription)

            //        };

            // 


            //var query = from e in _northwndContext.Employees
            //            from r in _northwndContext.Territories
            //            where e.EmployeeId == EmployeeId
            //            select r;

            //var quer2y = from t in _northwndContext.Territories
            //            from r in _northwndContext.Employees

            //            select t;
            //var query = from article in db.Articles
            //            where article.Categories.Any(c => c.Category_ID == cat_id)
            //            select article;
            //var query = from t in _northwndContext.Territories
            //            where t.Employees.Any(t => t.EmployeeId == EmployeeId)
            //            join e in _northwndContext.Employees on t.Employees.Any(t => t.EmployeeId == EmployeeId) equals e.EmployeeId
            //            select t;   
            //var query = from t in _northwndContext.Territories
            //            from e in _northwndContext.Employees
            //            where e.EmployeeId == EmployeeId
            //            select t;//Hepsi geldi
            //var query = from t in _northwndContext.Territories
            //            from e in _northwndContext.Employees
            //            where EmployeeId.Equals(e.EmployeeId)
            //            select t; // hepsi geldi
            //var query = from e in _northwndContext.Employees
            //            where e.EmployeeId == EmployeeId
            //            from t in _northwndContext.Territories
            //            where t.Employees.Contains(e)
            //            select t;
            //var query = _northwndContext.Employees.SelectMany(x => x.Territories,
            //    (x, t) => new EmployeeTerritoryViewModel
            //    {
            //        EmployeeId = x.EmployeeId,
            //        TerritoryId = t.TerritoryId,

            //        TerritoryDescription = t.TerritoryDescription
            //    });//DTO İLE de olmadı
            //var employee = _northwndContext.Employees.Where(employee => employee.EmployeeId == EmployeeId).
            //    Select(employee => new
            //    {
            //        EmployeeId = employee.EmployeeId,
            //        Territory = employee.Territories.Select(Territory => new Territory
            //        {
            //            TerritoryId = Territory.TerritoryId,
            //            TerritoryDescription = Territory.TerritoryDescription,
            //        })
            //    }).First();//EmployeeTerritory
            //var employee = _northwndContext.Employees.Where(x => x.EmployeeId == EmployeeId)
            //    .Include(t => t.Territories).First();
            //var territory = _northwndContext.Territories.Include(x => x.Employees.Any(y=>y.EmployeeId == EmployeeId));
            //var empTer = employee.Territories.Select(x => x.Employees.FirstOrDefault(y => y.EmployeeId == EmployeeId)).FirstOrDefault();

            //var query = from e in _northwndContext.Employees
            //            join t in _northwndContext.Territories on e.EmployeeId equals t.EmployeeId

            //            select t; //territory içine EmployeeId set içinde diğer kodlar patladı (map edemediği için)
            //var query = from t in _northwndContext.Territories
            //           where t.Employees.EmployeeId
            //            select t;
            #endregion
            //var territory = _northwndContext.Territories.AsNoTracking().Where(t => t.Employees.All(x => x.EmployeeId == EmployeeId)).ToList();

            var query = from t in _northwndContext.Territories
                        from e in _northwndContext.Employees
                        where e.EmployeeId == EmployeeId 

                        select t;//Hepsi geldi
          
            
            return View(query);

        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            string message = "Çalışan başarıyla eklendi";
            if (!ModelState.IsValid)
            {
                return View();

            }
            
            _northwndContext.Employees.Add(employee);
            _northwndContext.SaveChanges();

            
            ViewBag.Message = message;
            return View();
        }
    }
}
