﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetListItems.cs" company="Devville">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Devville.DataService.SharePointOperations
{
    using System.Data;
    using System.Web;

    using Devville.DataService.Contracts;
    using Devville.DataService.Contracts.ServiceResponses;

    /// <summary>
    /// The get list items.
    /// </summary>
    public class GetListItems : IServiceOperation
    {
        #region Public Properties

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        /// <author>Ahmed Magdy (ahmed.magdy@devville.net)</author>
        /// <created>12/28/2014</created>
        public string Name
        {
            get
            {
                return "GetSPListItems";
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <author>Ahmed Magdy (ahmed.magdy@devville.net)</author>
        /// <created>2/23/2015</created>
        /// <created>2/23/2015</created>
        public string Description
        {
            get
            {
                return "Gets SharePoint ListItems by: 'SiteUrl', 'ListUrl' and 'ViewName'. You can 'ConvertToUmAlQura' to true if you want to have create a new date columns to UmAlQura." + Constants.OperationDescription;
            }
        }


        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Executes the current service operation.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The Service Response
        /// </returns>
        /// <author>Ahmed Magdy (ahmed.magdy@devville.net)</author>
        /// <created>12/28/2014</created>
        /// <exception cref="System.MissingFieldException">
        /// Can't find ListUrl parameter
        /// </exception>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Can't find list associated with the following URL:  + siteUrl
        /// </exception>
        public IServiceResponse Execute(HttpContext context)
        {
            DataTable results = Common.GetListItemsByViewAsDataTable(context);
            var serviceResponse = new JsonResponse(new { Items = results });
            return serviceResponse;
        }

        #endregion
    }
}