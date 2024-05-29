


using DevExpress.Blazor;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WebAppProject.Data;
using WebAppProject.Data.Models;

namespace WebAppProject.ViewModels.Product
{
    
    public class ProductsViewModel : IProductsViewModel
    {
        private readonly IProductDataService productDataService;

        public  ProductsViewModel(IProductDataService productDataService)
        {
            this.productDataService = productDataService;

            Task.Run(async () =>
            {
                products = await this.productDataService.GetProducts();
            })
            .GetAwaiter()
            .GetResult();

        }



        private List<ProductModel> products = new List<ProductModel>();

        public List<ProductModel> Products
        { 
            get
            {
                return products;
            }
        }

        public async void DeletingProduct(GridDataItemDeletingEventArgs e)
        {
            products.Remove(e.DataItem as ProductModel);
            await this.productDataService.DeleteProduct(e.DataItem as ProductModel);
        }

        public async void EditProduct(GridEditModelSavingEventArgs e)
        {
            ProductModel editModel = (ProductModel)e.EditModel;
            ProductModel newProduct = e.IsNew ? new ProductModel() : (ProductModel)e.DataItem;

            newProduct.Name = editModel.Name;
            newProduct.Price = editModel.Price;
            newProduct.DateAdded = editModel.DateAdded;

            if (e.IsNew)
            {
                newProduct.Id = Guid.NewGuid();
                products.Add(newProduct as ProductModel);
                await this.productDataService.InsertProduct(newProduct);
            }
            else 
            {
                await this.productDataService.UpdateProduct(newProduct);
            }
        }

        public void CustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {
                var editModel = (ProductModel)e.EditModel;
                editModel.DateAdded = DateTime.UtcNow;
            }
        }
    }
}
