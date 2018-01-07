using Android.App;
using Android.OS;
using Android.Widget;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace TabLayoutSample
{
    [Activity(Label = "TabLayout Samples", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        SamplesAdapter _adapter;
        List<Sample> _samples;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _samples = new List<Sample>
            {
                new Sample { Name = "Simple Tabs", ActivityType = typeof(SimpleTabsActivity) },
                new Sample { Name = "Centered Tabs", ActivityType = typeof(CenteredTabsActivity) },
                new Sample { Name = "Scrollable Tabs", ActivityType = typeof(ScrollableTabsActivity) },
                new Sample { Name = "Icon & Text Tabs", ActivityType = typeof(IconTextTabsActivity) },
                new Sample { Name = "Icon Tabs", ActivityType = typeof(IconTabsActivity) },
                new Sample { Name = "Custom Tabs", ActivityType = typeof(CustomTabsActivity) },
            };

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            _adapter = new SamplesAdapter(this, _samples);
            recyclerView.SetAdapter(_adapter);

            _adapter.ItemClick += OnItemClick;
        }

        void OnItemClick(object sender, int position)
        {
            StartActivity(_samples[position].ActivityType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_adapter != null)
                    _adapter.ItemClick -= OnItemClick;
            }

            base.Dispose(disposing);
        }
    }

    [Activity(Label = "Simple Tabs")]
    public class SimpleTabsActivity : BaseTabsActivity
    {
        protected override int NumberOfTabs => 3;
        protected override int LayoutId => Resource.Layout.activity_simpletabs;
    }

    [Activity(Label = "Centered Tabs")]
    public class CenteredTabsActivity : BaseTabsActivity
    {
        protected override int NumberOfTabs => 3;
        protected override int LayoutId => Resource.Layout.activity_centeredtabs;
    }

    [Activity(Label = "Scrollable Tabs")]
    public class ScrollableTabsActivity : BaseTabsActivity
    {
        protected override int NumberOfTabs => 10;
        protected override int LayoutId => Resource.Layout.activity_scrollabletabs;
    }

    [Activity(Label = "Icon & Text Tabs")]
    public class IconTextTabsActivity : BaseTabsActivity
    {
        protected override int NumberOfTabs => 3;
        protected override int LayoutId => Resource.Layout.activity_simpletabs;

        protected override void SetupIcons()
        {
            TabLayout.GetTabAt(0).SetIcon(Resource.Drawable.ic_cloud_white_24dp);
            TabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_grade_white_24dp);
            TabLayout.GetTabAt(2).SetIcon(Resource.Drawable.ic_mood_white_24dp);
        }
    }

    [Activity(Label = "Icon Tabs")]
    public class IconTabsActivity : BaseTabsActivity
    {
        protected override int NumberOfTabs => 3;
        protected override int LayoutId => Resource.Layout.activity_simpletabs;

        protected override ViewPagerAdapter CreateViewPagerAdapter(FragmentManager fragmentManager)
        {
            return new ViewPagerAdapter(fragmentManager, false);
        }

        protected override void SetupIcons()
        {
            TabLayout.GetTabAt(0).SetIcon(Resource.Drawable.ic_cloud_white_24dp);
            TabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_grade_white_24dp);
            TabLayout.GetTabAt(2).SetIcon(Resource.Drawable.ic_mood_white_24dp);
        }
    }

    [Activity(Label = "Custom Tabs")]
    public class CustomTabsActivity : BaseTabsActivity
    {
        protected override int NumberOfTabs => 3;
        protected override int LayoutId => Resource.Layout.activity_customtabs;

        protected override void SetupIcons()
        {
            var icons = new[]
            {
                Resource.Drawable.ic_cloud_white_24dp,
                Resource.Drawable.ic_grade_white_24dp,
                Resource.Drawable.ic_mood_white_24dp
            };

            for (var i = 0; i < NumberOfTabs; i++)
            {
                var textView = LayoutInflater.Inflate(Resource.Layout.custom_tab, null, false).JavaCast<TextView>();
                textView.Text = NumberToWords(i + 1);
                textView.SetCompoundDrawablesWithIntrinsicBounds(0, 0, icons[i], 0);

                TabLayout.GetTabAt(i).SetCustomView(textView);
            }
        }
    }
}

