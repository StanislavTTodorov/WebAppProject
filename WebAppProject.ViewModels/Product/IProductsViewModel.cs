using DevExpress.Blazor;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WebAppProject.Data.Models;

namespace WebAppProject.ViewModels.Product
{
    public interface IProductsViewModel
    {
        List<ProductModel> Products { get; }

        void CustomizeEditModel(GridCustomizeEditModelEventArgs e);
        void DeletingProduct(GridDataItemDeletingEventArgs e);
        void EditProduct(GridEditModelSavingEventArgs e);
    }
}