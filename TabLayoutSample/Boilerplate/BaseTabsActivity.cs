using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using TabLayoutSample.Fragments;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace TabLayoutSample
{
    public abstract class BaseTabsActivity : AppCompatActivity
    {
        protected abstract int NumberOfTabs { get; }
        protected abstract int LayoutId { get; }
        protected TabLayout TabLayout { get; private set; }
        protected ViewPager ViewPager { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(LayoutId);

            TabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            ViewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            var viewPagerAdapter = CreateViewPagerAdapter(SupportFragmentManager);

            CreateTabs(viewPagerAdapter);

            ViewPager.Adapter = viewPagerAdapter;
            TabLayout.SetupWithViewPager(ViewPager);

            SetupIcons();
        }

        protected virtual ViewPagerAdapter CreateViewPagerAdapter(FragmentManager fragmentManager)
        {
            var viewPagerAdapter = new ViewPagerAdapter(SupportFragmentManager, true);

            return viewPagerAdapter;
        }

        protected virtual void CreateTabs(ViewPagerAdapter adapter)
        {
            for (var i = 0; i < NumberOfTabs; i++)
                adapter.AddFragment(new BaseFragment($"Fragment {i + 1}"), NumberToWords(i + 1));
        }

        protected virtual void SetupIcons()
        {
        }

        public static string NumberToWords(int number)
        {
            string words = "";
            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };

            if (number < 11)
                words += unitsMap[number];

            return words;
        }
    }
}

