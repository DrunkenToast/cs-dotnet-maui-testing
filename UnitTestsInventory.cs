using cs_dotnet_maui;
using cs_dotnet_maui.Views;
using System.Net.NetworkInformation;

namespace cs_dotnet_maui_testing
{
    public class UnitTestsInventory
    {
        public static IEnumerable<object[]> Items
        {
            get
            {
                yield return new object[] { new List<Item>() {} }; // empty test case
                yield return new object[] { new List<Item>() { new Item() } }; // test case 1 item
                yield return new object[] { new List<Item>() { 
                    new Item(),
                    new Item(),
                    new Item(),
                    new Item(),
                    new Item()
                } }; // test case multiple items
            }
        }

        // Unit test 1
        [Fact]
        public void SettingSelectedItemRaisesPropertyChanged()
        {
            // Arrange
            var raised = false;
            var inventoryVm = new InventoryViewModel(null);

            // Act
            inventoryVm.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("SelectedItem")) { raised = true; }
            };

            inventoryVm.SelectedItem = new();

            // Assert
            Assert.True(raised);
        }

        // Unit test 2
        [Theory]
        [MemberData(nameof(Items))]
        public void UpdatingItemListFunctionUpdatesObservableCollection(IEnumerable<Item> items)
        {
            // Arrange
            var inventoryVm = new InventoryViewModel(null);

            // Act
            inventoryVm.UpdateItemList(items);

            // Assert
            Assert.Equal(inventoryVm.ItemList.ToList(), items);
        }
    }
}