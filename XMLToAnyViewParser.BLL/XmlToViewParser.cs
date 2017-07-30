using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.BLL.Interfaces;
using XMLToAnyViewParser.BLL.Services;
using XMLToAnyViewParser.BLL.Services.Interfaces;

namespace XMLToAnyViewParser.BLL
{
    public class XmlToViewParser
    {
        #region Data members

        private static XmlToViewParser service;

        private IViewPathService viewService;

        private ITemplatePathService templateService;

        private IViewsTransformatter viewsTransformatter;

        private IFormResolver formResolver;

        #endregion

        #region Constructors

        private XmlToViewParser()
        {
            // instance every property

            this.viewService = new ViewPathService();
            this.templateService = new TemplatePathService();
            this.viewsTransformatter = new ViewsTransformatter();
            this.formResolver = new FormResolver();
        }

        #endregion

        #region Properties

        // implementation of Singleton pattern
        public static XmlToViewParser Service
        {
            get
            {
                if(service == null)
                {
                    service = new XmlToViewParser();
                }

                return service;
            }
        }

        public IViewPathService ViewService
        {
            get
            {
                return this.viewService;
            }
        }

        public ITemplatePathService TemplateService
        {
            get
            {
                return this.templateService;
            }
        }

        public IViewsTransformatter ViewsTransformatter
        {
            get
            {
                return viewsTransformatter;
            }
        }

        public IFormResolver FormResolver
        {
            get
            {
                return formResolver;
            }
        }

        #endregion

        #region Public methods
        #endregion

        #region Private methods
        #endregion
    }
}
