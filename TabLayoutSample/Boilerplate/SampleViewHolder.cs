using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace TabLayoutSample
{
    public class SampleViewHolder : RecyclerView.ViewHolder
    {
        Action<int> _clickListener;
        public TextView TextView { get; }

        public SampleViewHolder(View itemView, Action<int> clickListener) : base(itemView)
        {
            TextView = itemView.FindViewById<TextView>(Resource.Id.text);
            _clickListener = clickListener;
            itemView.Click += OnItemViewClick;
        }

        private void OnItemViewClick(object sender, EventArgs e)
        {
            _clickListener?.Invoke(LayoutPosition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (ItemView != null)
                    ItemView.Click -= OnItemViewClick;
            }

            base.Dispose(disposing);
        }
    }
}

