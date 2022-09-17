using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Entities
{
    public class SitePage : BaseEntity
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        /// <summary>
        /// Common
        /// </summary>
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string KeyWords { get; set; } = string.Empty;
        public string NewKeyWords { get; set; } = string.Empty;
        public string AppleMobileWebAppCapable { get; set; } = string.Empty;
        public string AppleMobileWebAppTitle { get; set; } = string.Empty;
        public string ArticleId { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public string SiteId { get; set; } = string.Empty;
        public string SiteIdNew { get; set; } = string.Empty;
        public string ListFolder { get; set; } = string.Empty;
        public string ListFolderName { get; set; } = string.Empty;
        public string PageType { get; set; } = string.Empty;
        public string PageTypeNew { get; set; } = string.Empty;
        /// <summary>
        /// Facebook
        /// </summary>
        public string OgSiteName { get; set; } = string.Empty;
        public string OgRichAttachment { get; set; } = string.Empty;
        public string OgType { get; set; } = string.Empty;
        public string OgUrl { get; set; } = string.Empty;
        public string OgImage { get; set; } = string.Empty;
        public string OgImageWidth { get; set; } = string.Empty;
        public string OgImageHeight { get; set; } = string.Empty;
        public string OgTitle { get; set; } = string.Empty;
        public string ArticleTags { get; set; } = string.Empty;
        public string OgDescription { get; set; } = string.Empty;
        public string ArticlePublisher{ get; set; } = string.Empty;

        /// <summary>
        /// Site
        /// </summary>
        public string Medium { get; set; } = string.Empty;
        public string InLanguage { get; set; } = string.Empty;
        public string ArticleSection { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Copyright { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Robots { get; set; } = string.Empty;
        public string GeoPlaceName { get; set; } = string.Empty;
        public string GeoRegion { get; set; } = string.Empty;
        public string GeoPosition { get; set; } = string.Empty;
        public string ICBM { get; set; } = string.Empty;
        public string RevisitAfter { get; set; } = string.Empty;

        /// <summary>
        /// Twitter
        /// </summary>
        public string TwitterCard { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string TwitterTitle { get; set; } = string.Empty;
        public string TwitterDescription { get; set; } = string.Empty;
        public string TwitterImage { get; set; } = string.Empty;
        public string TwitterSite { get; set; } = string.Empty;
        public string TwitterCreator { get; set; } = string.Empty;

        /// <summary>
        /// Google
        /// </summary>
        public string PubDate { get; set; } = string.Empty;
        public string LastMod { get; set; } = string.Empty;

        public SitePage SetCommon(string title, string keywords, string description)
        {
            this.Title = title;
            this.KeyWords = keywords;
            this.Description = description;
            return this;
        }

        public SitePage SetUrl(string url)
        {
            this.OgUrl = url;
            this.TwitterUrl = url;
            return this;
        }

        public SitePage SetData(string? title, string? keywords,
            string? description, string? image, string? url)
        {
            this.Title = title ?? string.Empty;
            this.OgTitle = title ?? string.Empty;
            this.TwitterTitle = title ?? string.Empty;

            this.KeyWords = keywords ?? string.Empty;
            this.Description = description ?? string.Empty;
            this.OgDescription = description ?? string.Empty;
            this.TwitterDescription = description ?? string.Empty;

            this.TwitterImage = image ?? string.Empty;
            this.OgImage = image ?? string.Empty;

            this.OgUrl = url ?? string.Empty;
            this.TwitterUrl = url ?? string.Empty;

            return this;
        }
    }
}
