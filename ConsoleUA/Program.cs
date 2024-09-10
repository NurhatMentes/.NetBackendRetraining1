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

    var result = productManager.GetAll();

    if (result.IsSuccess)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.ProductName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

static void ProductTest2()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    var result = productManager.GetProductDetails(); 

     if (result.IsSuccess)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.ProductName + " : " + item.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
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