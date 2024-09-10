// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//ProductTest();

ProductTest2();

//CategoryTest();



//****Test Methods****
static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var item in productManager.GetAll())
    {
        Console.WriteLine(item.ProductName);
    }
}

static void ProductTest2()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var item in productManager.GetProductDetails())
    {
        Console.WriteLine(item.ProductName + " : " + item.CategoryName);
    }
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var item in categoryManager.GetAll())
    {
        Console.WriteLine(item.CategoryName);
    }
}