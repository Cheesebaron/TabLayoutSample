using Android.Support.V4.App;
using Java.Lang;
using System.Collections.Generic;
using TabLayoutSample.Fragments;

namespace TabLayoutSample
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        List<BaseFragment> _fragments = new List<BaseFragment>();
        List<string> _titles = new List<string>();
        readonly bool _useTitles;

        public ViewPagerAdapter(FragmentManager fragmentManager, bool useTitles) : base(fragmentManager)
        {
            _useTitles = useTitles;
        }

        public override int Count => _fragments.Count;

        public override Fragment GetItem(int position)
        {
            return _fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            if (_useTitles)
                return new String(_titles[position]);
            else
                return null;
        }

        public void AddFragment(BaseFragment fragment, string title)
        {
            _fragments.Add(fragment);
            _titles.Add(title);
        }
    }
}

