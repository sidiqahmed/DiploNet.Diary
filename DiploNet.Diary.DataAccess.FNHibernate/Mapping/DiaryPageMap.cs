using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.BusinessObject.Impl;
using FluentNHibernate.Mapping;

namespace DiploNet.Diary.DataAccess.FNHibernate.Mapping
{
    internal class DiaryPageMap : ClassMap<DiaryPage>
    {
        public DiaryPageMap()
        {
            Table("DiaryPage");

            Id(x => x.Id, "diarypageid")
                .GeneratedBy.Identity();

            Map(x => x.Description, "description")
                .Not.Nullable()
                .Length(128);

            Map(x => x.ShortDescription, "shortdesc")
                .Nullable()
                .Length(50);

            Map(x => x.Text, "text")
                .Not.Nullable();

            Map(x => x.Title, "title")
                .Not.Nullable()
                .Length(50);
        }
    }
}
