using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukyBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;

namespace BukyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            //_db.Products.Update(obj);
            var ObjFromDb = _db.Products.FirstOrDefault(x => x.Id == obj.Id); 
            if(ObjFromDb != null)
            {
                ObjFromDb.Title = obj.Title;
                ObjFromDb.Description = obj.Description;
                ObjFromDb.ISBN = obj.ISBN;
                ObjFromDb.Price = obj.Price;
                ObjFromDb.Price50 = obj.Price50;
                ObjFromDb.Price100 = obj.Price100;
                ObjFromDb.ListPrice = obj.ListPrice;
                ObjFromDb.Author = obj.Author;
                ObjFromDb.CategoryId = obj.CategoryId;
                ObjFromDb.CoverTypeId = obj.CoverTypeId;

                if (obj.ImageUrl != null)
                {
                    ObjFromDb.ImageUrl = obj.ImageUrl;
                }

            }   
        }
    }
}
