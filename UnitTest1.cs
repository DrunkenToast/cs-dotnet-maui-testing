using cs_dotnet_maui.Views;

namespace cs_dotnet_maui_testing
{
    public class UnitTest1
    {
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
    }
}