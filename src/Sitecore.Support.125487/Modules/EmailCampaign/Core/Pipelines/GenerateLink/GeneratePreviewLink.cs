// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneratePreviewLink.cs" company="Sitecore A/S">
//   Copyright (C) Sitecore A/S. All rights reserved.
// </copyright>
// <summary>
//   Defines the GeneratePreviewLink type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Support.Modules.EmailCampaign.Core.Pipelines.GenerateLink
{
  using System.Text;
  using System.Web;
  using Diagnostics;   
  using Sitecore.Modules.EmailCampaign.Core.Pipelines.GenerateLink;
  using Sitecore.Modules.EmailCampaign.Core.Links;
  

  /// <summary>
  /// Processor which generates preview links
  /// </summary>
  public partial class GeneratePreviewLink : GenerateLinkProcessor
  {
    /// <summary> Processes the arguments and generates modified preview link. </summary>
    /// <param name="args"> The <see cref="GenerateLinkPipelineArgs"/>. arguments</param>
    public override void Process(GenerateLinkPipelineArgs args)
    {
      Assert.IsNotNull(args, "Arguments can't be null");
      Assert.IsNotNull(args.Url, "Url can't be null");
      Assert.IsNotNull(args.ServerUrl, "Server url link can't be null");

      if (!args.PreviewMode)
      {
        return;
      }

      var link = new StringBuilder();

      if (!LinksManager.IsAbsoluteLink(args.Url))
      {
        link.Append(string.IsNullOrEmpty(args.MailMessage.ManagerRoot.Settings.PreviewBaseURL) ? args.ServerUrl : args.MailMessage.ManagerRoot.Settings.PreviewBaseURL);
      }

      link.Append(HttpUtility.HtmlDecode(args.Url));

      args.GeneratedUrl = link.ToString();
    }
  }
}
