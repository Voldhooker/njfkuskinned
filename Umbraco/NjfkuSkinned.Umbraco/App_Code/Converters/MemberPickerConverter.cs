using NJFKModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Newtonsoft.Json;

namespace NjfkuSkinned.Umbraco.App_Code.Converters
{

    //https://github.com/Jeavon/Umbraco-Core-Property-Value-Converters/blob/v3/Our.Umbraco.PropertyConverters/MultiNodeTreePickerPropertyConverter.cs
    public class MemberPickerConverter : IPropertyValueConverter
    {
        public bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias == "TarSoft.MemberPicker";
        }

        public object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            var selected = JsonConvert.DeserializeObject<MemberPickerModel []>(source.ToString());
            return selected;
        }

        public object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            // Get the data type "content" or "media" setting
            /*
            var dts = ApplicationContext.Current.Services.DataTypeService;
            var startNodePreValue =
                dts.GetPreValuesCollectionByDataTypeId(propertyType.DataTypeId)
                    .PreValuesAsDictionary.FirstOrDefault(x => x.Key.ToLowerInvariant() == "startNode".ToLowerInvariant()).Value.Value;
            var startNodeObj = JsonConvert.DeserializeObject<JObject>(startNodePreValue);
            var pickerType = startNodeObj.GetValue("type").Value<string>();
            */

            //if (source == null)
            //{
            //    return null;
            //}

            //if (UmbracoContext.Current != null)
            //{
            //    var nodeIds = (int[])source;

            //    if (!(propertyType.PropertyTypeAlias != null && PropertiesToExclude.InvariantContains(propertyType.PropertyTypeAlias)))
            //    {
            //        var multiNodeTreePicker = new List<IPublishedContent>();

            //        var dynamicInvocation = ConverterHelper.DynamicInvocation();

            //        var umbHelper = new UmbracoHelper(UmbracoContext.Current);

            //        if (nodeIds.Length > 0)
            //        {
            //            var objectType = UmbracoObjectTypes.Unknown;

            //            foreach (var nodeId in nodeIds)
            //            {
            //                var multiNodeTreePickerItem = GetPublishedContent(nodeId, ref objectType, UmbracoObjectTypes.Document, umbHelper.TypedContent)
            //                            ?? GetPublishedContent(nodeId, ref objectType, UmbracoObjectTypes.Media, umbHelper.TypedMedia)
            //                            ?? GetPublishedContent(nodeId, ref objectType, UmbracoObjectTypes.Member, umbHelper.TypedMember);

            //                if (multiNodeTreePickerItem != null)
            //                {
            //                    multiNodeTreePicker.Add(dynamicInvocation ? multiNodeTreePickerItem.AsDynamic() : multiNodeTreePickerItem);
            //                }
            //            }
            //        }
            //        return dynamicInvocation
            //                    ? new DynamicPublishedContentList(multiNodeTreePicker.Where(x => x != null))
            //                    : multiNodeTreePicker.Yield().Where(x => x != null);
            //    }

            //    // return the first nodeId as this is one of the excluded properties that expects a single id
            //    return nodeIds.FirstOrDefault();
            //}
            //else
            //{
            //    return null;
            //}

            return MemberPickerModel.Deserialize(source as string);
        }

        public object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            return null;
        }

    }
}