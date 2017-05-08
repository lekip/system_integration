using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClassLibrary
{
    public class WebArticle
    {
        public String title = "";
        DateTime? dataChanged = null;
        DateTime? publishStart = null;
        DateTime? publishEnd = null;
        String articleText = "";
        String publishedArticleText = "";

        public void setArticleText(String articleText)
        {
            dataChanged = DateTime.Now;
            this.articleText=articleText;
        }

        public String getArticleText()
        {
            return articleText;
        }

        public String getPublishedArticleText()
        {
            return publishedArticleText;
        }

        public void publish(int daysToPublish)
        {
            publishStart = DateTime.Now;
            publishEnd = publishStart.Value.AddDays(daysToPublish);
            publishedArticleText = articleText;
        }

        public void setPublishDates(DateTime? publishStart, DateTime? publishEnd)
        {
            if (
                !(
                    publishStart.HasValue && publishEnd.HasValue && publishStart.Value > publishEnd.Value)
                 )
            {
                this.publishStart = publishStart;
                this.publishEnd = publishEnd;
            }
        }

        public void unPublish()
        {
            publishStart = null;
            publishEnd = null;
        }

        public override string ToString()
        {
            return "Overskrift: "+title;
        }
    }
}
