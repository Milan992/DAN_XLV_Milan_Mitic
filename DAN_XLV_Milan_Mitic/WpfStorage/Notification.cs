using System;
using System.Windows;

namespace WpfStorage
{
    class Notification
    {
        internal void ProductDeleted(object source, EventArgs args)
        {
            MessageBox.Show("Product deleted.");
        }

        internal void ProductAdded(object source, EventArgs args)
        {
            MessageBox.Show("Product added.");
        }

        internal void ProductEdited(object source, EventArgs args)
        {
            MessageBox.Show("Product edited.");
        }

        internal void ProductStored(object source, EventArgs args)
        {
            MessageBox.Show("Product stored.");
        }

        internal void ProductNotStored(object source, EventArgs args)
        {
            MessageBox.Show("Product is not stored. Not enough room in storage for that amount");
        }
    }
}
