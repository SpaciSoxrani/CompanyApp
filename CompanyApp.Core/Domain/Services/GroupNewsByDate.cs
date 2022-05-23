using CompanyApp.Core.Domain.Models;

namespace CompanyApp.Core.Domain.Services;

public class GroupNewsByDate
{
    public Dictionary<DateOnly, List<MainTitle>> ReturnGroupsByDate(List<MainTitle> news)
    {
        //Dictionary<DateTime, NewsDateGroup> newsDateGroups = new Dictionary<DateTime, NewsDateGroup>();
        Dictionary<DateOnly, List<MainTitle>> newsDateGroupsDict = new Dictionary<DateOnly, List<MainTitle>>();
        news.Sort(delegate(MainTitle title, MainTitle mainTitle)
        {
            if(title.DateTime == null && mainTitle.DateTime == null) return 0;
            else if (title.DateTime == null) return -1;
            else if (mainTitle.DateTime == null) return 1;
            else return title.DateTime.CompareTo(mainTitle.DateTime);
        });
        
        foreach (var mailing in news)
        {
            DateOnly date = DateOnly.FromDateTime(mailing.DateTime);
            if (!newsDateGroupsDict.ContainsKey(date))
            {
                List<MainTitle> mailingsList = new List<MainTitle>();
                mailingsList.Add(mailing);
                newsDateGroupsDict.Add(date, mailingsList);
            }
            else
            {
                var existMailingList = newsDateGroupsDict[date];
                if (!existMailingList.Exists(x => x.Name == mailing.Name))
                {
                    newsDateGroupsDict[date].Add(mailing);
                }
                    
            }
        }

        return newsDateGroupsDict;
    }
}