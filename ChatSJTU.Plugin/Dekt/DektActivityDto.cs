using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Dekt
{
    public partial class DektActivityDto
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public System.Collections.Generic.List<DektActivityDataDto> Data { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }

    public partial class DektActivityDataDto
    {
        [JsonProperty("activeDuration")]
        public object ActiveDuration { get; set; }

        [JsonProperty("activeDurationDesc")]
        public string ActiveDurationDesc { get; set; }

        [JsonProperty("activeEndTime")]
        public long ActiveEndTime { get; set; }

        [JsonProperty("activePeriod")]
        public System.Collections.Generic.List<ActivePeriod> ActivePeriod { get; set; }

        [JsonProperty("activePeriodArray")]
        public string ActivePeriodArray { get; set; }

        [JsonProperty("activeStartTime")]
        public long ActiveStartTime { get; set; }

        [JsonProperty("activeType")]
        public long ActiveType { get; set; }

        [JsonProperty("activityAddress")]
        public string ActivityAddress { get; set; }

        [JsonProperty("activityCategorya")]
        public string ActivityCategorya { get; set; }

        [JsonProperty("activityCode")]
        public string ActivityCode { get; set; }

        [JsonProperty("activityContentInfo")]
        public string ActivityContentInfo { get; set; }

        [JsonProperty("activityContentType")]
        public long ActivityContentType { get; set; }

        [JsonProperty("activityDesc")]
        public string ActivityDesc { get; set; }

        [JsonProperty("activityEnrollInfo")]
        public string ActivityEnrollInfo { get; set; }

        [JsonProperty("activityEnrollType")]
        public long ActivityEnrollType { get; set; }

        [JsonProperty("activityLevel")]
        public long ActivityLevel { get; set; }

        [JsonProperty("activityLevelCode")]
        public string ActivityLevelCode { get; set; }

        [JsonProperty("activityName")]
        public string ActivityName { get; set; }

        [JsonProperty("activityPicurl")]
        public string ActivityPicurl { get; set; }

        [JsonProperty("activityStatus")]
        public long ActivityStatus { get; set; }

        [JsonProperty("activitySupport")]
        public System.Collections.Generic.List<ActivitySupport> ActivitySupport { get; set; }

        [JsonProperty("activityTopic")]
        public long ActivityTopic { get; set; }

        [JsonProperty("activityTopicCode")]
        public string ActivityTopicCode { get; set; }

        [JsonProperty("createUserId")]
        public object CreateUserId { get; set; }

        [JsonProperty("enrollCollege")]
        public string EnrollCollege { get; set; }

        [JsonProperty("enrollDegree")]
        public string EnrollDegree { get; set; }

        [JsonProperty("enrollEndTime")]
        public long EnrollEndTime { get; set; }

        [JsonProperty("enrollGrade")]
        public string EnrollGrade { get; set; }

        [JsonProperty("enrollStartTime")]
        public long EnrollStartTime { get; set; }

        [JsonProperty("enrollType")]
        public long EnrollType { get; set; }

        [JsonProperty("fullAuthorizeCollege")]
        public object FullAuthorizeCollege { get; set; }

        [JsonProperty("fullAuthorizePerson")]
        public object FullAuthorizePerson { get; set; }

        [JsonProperty("fullOrPartial")]
        public object FullOrPartial { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isAtSchool")]
        public bool IsAtSchool { get; set; }

        [JsonProperty("isCollect")]
        public object IsCollect { get; set; }

        [JsonProperty("isEnroll")]
        public object IsEnroll { get; set; }

        [JsonProperty("isLaborEducation")]
        public object IsLaborEducation { get; set; }

        [JsonProperty("isNeedCheckin")]
        public bool IsNeedCheckin { get; set; }

        [JsonProperty("isNeedCheckout")]
        public bool IsNeedCheckout { get; set; }

        [JsonProperty("isRedTour")]
        public object IsRedTour { get; set; }

        [JsonProperty("jsonArray")]
        public string JsonArray { get; set; }

        [JsonProperty("laborClassHour")]
        public object LaborClassHour { get; set; }

        [JsonProperty("laborType")]
        public object LaborType { get; set; }

        [JsonProperty("partialAuthorizeCollege")]
        public object PartialAuthorizeCollege { get; set; }

        [JsonProperty("partialAuthorizePerson")]
        public object PartialAuthorizePerson { get; set; }

        [JsonProperty("publishActivityTime")]
        public object PublishActivityTime { get; set; }

        [JsonProperty("recruitQty")]
        public long RecruitQty { get; set; }

        [JsonProperty("sponsor")]
        public string Sponsor { get; set; }

        [JsonProperty("targetNames")]
        public object TargetNames { get; set; }

        [JsonProperty("unEnrollMsg")]
        public object UnEnrollMsg { get; set; }

        [JsonProperty("visitCount")]
        public long VisitCount { get; set; }
    }

    public partial class ActivePeriod
    {
        [JsonProperty("activityAddress")]
        public string ActivityAddress { get; set; }

        [JsonProperty("activityEndTime")]
        public string ActivityEndTime { get; set; }

        [JsonProperty("activityStartTime")]
        public string ActivityStartTime { get; set; }

        [JsonProperty("periodIndex")]
        public long PeriodIndex { get; set; }

        [JsonProperty("recruitQty")]
        public long RecruitQty { get; set; }
    }

    public partial class ActivitySupport
    {
        [JsonProperty("contactInfo")]
        public string ContactInfo { get; set; }

        [JsonProperty("contactName")]
        public string ContactName { get; set; }
    }

    public partial class ActivityContentInfoDto
    {
        [JsonProperty("drag")]
        public ActivityContentInfoTemplateDto Drag { get; set; }

        [JsonProperty("template")]
        public ActivityContentInfoTemplateDto Template { get; set; }
    }

    public partial class ActivityContentInfoTemplateDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
