using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Enums
{
    /// <summary>
    /// 字典类型
    /// </summary>
    public enum DataDictionaryType
    {
        [Description("安管证书专业")]
        Security_certificate_professional,

        [Description("币种")]
        currency,

        [Description("初级职称人员类别")]
        Category_of_junior_professional_title,

        [Description("单位性质")]
        unit_of_nature,

        [Description("岗位证书专业")]
        Post_certificate_major,

        [Description("高级职称人员类别")]
        Category_of_senior_professional_title,

        [Description("工程用途")]
        engineering_purposes,

        [Description("工人不良行为类别")]
        type_of_bad_behavior_of_workers,

        [Description("工人奖励对象")]
        object_of_worker_reward,

        [Description("工人奖励级别")]
        worker_award_level,

        [Description("工人奖励类别")]
        category_of_worker_award,

        [Description("工种字典数据")]
        work_type,

        [Description("技术工人类别")]
        Category_of_skilled_workers,

        [Description("建设规模")]
        construction_scale,

        [Description("建设性质分类")]
        construction_property_classification,

        [Description("勘察设计注册工程师不良记录认定行为标（N1）")]
        N1,

        [Description("立项级别")]
        project_level,

        [Description("企业资质")]
        enterprise_qualification,

        [Description("企业资质等级")]
        Enterprise_qualification_level,

        [Description("人员证件类型")]
        type_of_personnel_certificate,

        [Description("项目分类")]
        project_classification,

        [Description("项目活动类型")]
        type_of_project_activity,

        [Description("项目培训类型")]
        type_of_project_training,

        [Description("项目状态")]
        project_status,

        [Description("证书类型")]
        authority,

        [Description("执业注册类别")]
        Category_of_practice_registration,

        [Description("执业注册证书专业")]
        Practicing_registration_certificate_major,

        [Description("职称等级")]
        Professional_qualification,

        [Description("职称证书专业")]
        Professional_title_certificate,

        [Description("职业技能人员等级")]
        Type_of_professional_skill_level,

        [Description("职业技能人员类别")]
        Type_of_occupational_skill_category,

        [Description("中级职称人员类别")]
        Category_of_intermediate_professional_title,

        [Description("注册监理工程师不良记录认定行为标准（Q1）")]
        Q1,

        [Description("注册建造师不良记录认定行为标准（P1）")]
        P1,

        [Description("注册建筑师不良记录认定行为标准（M1）")]
        M1,

        [Description("资金来源")]
        sources_of_funding,
    }
}
