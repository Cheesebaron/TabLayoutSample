using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace TabLayoutSample.Fragments
{
    public class BaseFragment : Fragment
    {
        int LayoutId => Resource.Layout.fragment_base;
        string Text { get; }

        public BaseFragment(string text)
        {
            Text = text;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(LayoutId, container, false);
            var textView = view.FindViewById<TextView>(Resource.Id.text);
            if (textView != null)
                textView.Text = Text;

            return view;
        } 
    }
}