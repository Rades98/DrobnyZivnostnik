namespace AxiosControls.Controls.EditControls
{
    using AxiosServices.Services.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Xamarin.Forms;

    public class AxiosPickerEdit : AxiosBaseEditControl
    {
        private static readonly ILocalizationService LocalizationService = DependencyService.Get<ILocalizationService>();

        private Picker _itemPicker;

        public AxiosPickerEdit()
        {
            _itemPicker.ItemsSource = ItemsSource;
            _itemPicker.SelectedItem = SelectedItem;

            _itemPicker.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        #region Bindable properties

        /// <summary>
        /// The placeholder property.
        /// </summary>
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(AxiosPickerEdit),
            propertyChanged: (bindable, oldVal, newVal) => ((AxiosPickerEdit)bindable).OnPlaceholderChanged((string)newVal)
        );

        /// <summary>
        /// The items source property.
        /// </summary>
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IList),
            typeof(AxiosPickerEdit),
            propertyChanged: (bindable, oldVal, newVal) => ((AxiosPickerEdit)bindable).OnItemsSourceChanged((IList)newVal)
        );

        /// <summary>
        /// The selected item property.
        /// </summary>
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
            nameof(SelectedItem),
            typeof(object),
            typeof(AxiosPickerEdit),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: (bindable, oldVal, newVal) => ((AxiosPickerEdit)bindable).OnSelectedItemChanged((object)newVal)
        );

        /// <summary>
        /// The item display binding property
        /// NOTE: Use the name of the property, you do not need to bind to this property.
        /// </summary>
        public static readonly BindableProperty ItemDisplayBindingProperty = BindableProperty.Create(
            nameof(ItemDisplayBinding),
            typeof(string),
            typeof(AxiosPickerEdit),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: (bindable, oldVal, newVal) => ((AxiosPickerEdit)bindable).OnItemDisplayBindingChanged((string)newVal)
        );


        /// <summary>
        /// The cell's placeholder (select a ....).
        /// </summary>
        /// <value>The placeholder.</value>
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        /// <summary>
        /// The cell's picker item source.
        /// </summary>
        /// <value>The items source.</value>
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Gets or sets the item display binding.
        /// </summary>
        /// <value>The item display binding.</value>
        public string ItemDisplayBinding
        {
            get => (string)GetValue(ItemDisplayBindingProperty);
            set => SetValue(ItemDisplayBindingProperty, value);
        }

        #endregion Bindable properties

        #region Property changed methods

        /// <summary>
        /// Called when PlaceholderProperty changes.
        /// </summary>
        /// <param name="newVal">New value.</param>
        private void OnPlaceholderChanged(string newVal)
        {
            _itemPicker.Title = LocalizationService.GetResourceByKey(newVal);
        }

        /// <summary>
        /// Called when ItemSourceProperty changes.
        /// </summary>
        private void OnItemsSourceChanged(IList list)
        {
            if ((list is List<string> stringList))
            {
                _itemPicker.ItemsSource = stringList.Select(s => LocalizationService.GetResourceByKey(s)).ToList();
            }

            _itemPicker.ItemsSource = list;
        }

        /// <summary>
        /// Called when SelectedItemProperty changes.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void OnSelectedItemChanged(object obj)
        {
            _itemPicker.SelectedItem = obj;
        }

        /// <summary>
        /// Called when ItemDisplayBindingProperty changes.
        /// </summary>
        /// <param name="newValue">New value.</param>
        private void OnItemDisplayBindingChanged(string newValue)
        {
            _itemPicker.ItemDisplayBinding = new Binding(newValue);
        }

        /// <summary>
        /// Called when ItemPicker's SelectedIndexChanged event fires.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedItem = (_itemPicker.SelectedIndex < 0 || _itemPicker.SelectedIndex > _itemPicker.Items.Count - 1) ? null : ItemsSource[_itemPicker.SelectedIndex];
        }

        #endregion Property changed methods

        public override View EditContent()
        {
            _itemPicker = new Picker()
            {
                BindingContext = this,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = FontSize,
                TextColor = FontColor,
            };


            _itemPicker.SetBinding(Picker.ItemsSourceProperty, nameof(ItemsSource));
            _itemPicker.SetBinding(Picker.SelectedItemProperty, nameof(SelectedItem), BindingMode.TwoWay);

            return _itemPicker;
        }
    }
}
