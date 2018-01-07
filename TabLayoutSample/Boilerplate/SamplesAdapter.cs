using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using System;
using System.Collections.Generic;

namespace TabLayoutSample
{
    public class SamplesAdapter : RecyclerView.Adapter
    {
        List<Sample> _samples;
        LayoutInflater _layoutInflater;

        public event EventHandler<int> ItemClick;

        public SamplesAdapter(Context context, List<Sample> samples)
        {
            _samples = samples;
            _layoutInflater = LayoutInflater.From(context);
        }

        public override int ItemCount => _samples.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is SampleViewHolder sampleHolder)
            {
                var sample = _samples[position];

                sampleHolder.TextView.Text = sample.Name;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = _layoutInflater.Inflate(Resource.Layout.sample_view, parent, false);

            var viewHolder = new SampleViewHolder(itemView, OnItemClick);

            return viewHolder;
        }

        private void OnItemClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }
}

