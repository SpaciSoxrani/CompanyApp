using CompanyApp.Core.Domain.Models;

namespace CompanyApp.Core.Domain.Services;

public class GroupNewsByDate
{
    public Dictionary<DateTime, List<MainTitle>> ReturnGroupsByDate(List<MainTitle> news)
    {
        //Dictionary<DateTime, NewsDateGroup> newsDateGroups = new Dictionary<DateTime, NewsDateGroup>();
        Dictionary<DateTime, List<MainTitle>> newsDateGroupsDict = new Dictionary<DateTime, List<MainTitle>>();
        news.Sort(delegate(MainTitle title, MainTitle mainTitle)
        {
            if(title.DateTime == null && mainTitle.DateTime == null) return 0;
            else if (title.DateTime == null) return -1;
            else if (mainTitle.DateTime == null) return 1;
            else return title.DateTime.CompareTo(mainTitle.DateTime);
        });
        
        foreach (var mailing in news)
        {
            if (!newsDateGroupsDict.ContainsKey(mailing.DateTime))
            {
                List<MainTitle> mailingsList = new List<MainTitle>();
                mailingsList.Add(mailing);
                newsDateGroupsDict.Add(mailing.DateTime, mailingsList);
            }
            else
            {
                var existMailingList = newsDateGroupsDict[mailing.DateTime];
                if (!existMailingList.Exists(x => x.Name == mailing.Name))
                {
                    newsDateGroupsDict[mailing.DateTime].Add(mailing);
                }
                    
            }
        }

        return newsDateGroupsDict;
    }
}