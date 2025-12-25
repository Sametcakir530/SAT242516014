using SAT242516014.Models.MyResources;

namespace SAT242516014.Filtering
{
    public class Student
    {
        [Sortable(true)]
        [Editable(false)]
        [Viewable(true)]
        [LocalizedDescription("Id", typeof(MyResource))]
        public int Id { get; set; }

        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("Ad", typeof(MyResource))]
        public string Ad { get; set; }

        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("Soyad", typeof(MyResource))]
        public string Soyad { get; set; }

        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("Email", typeof(MyResource))]
        public string Email { get; set; }

        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("Numara", typeof(MyResource))]
        public string Numara { get; set; }

        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("DoğumTarihi", typeof(MyResource))]
        public string DoğumTarihi { get; set; }


        [Sortable(true)]
        [Editable(true)]
        [Viewable(true)]
        [LocalizedDescription("Tc", typeof(MyResource))]
        public string Tc { get; set; }




    }
}
