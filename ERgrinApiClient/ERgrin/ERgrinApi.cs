using System.Runtime.InteropServices;

namespace ERgrin.Api
{
    [ComImport]
    [CoClass(typeof(ProjectClass))]
    [Guid(ApiGuids.ProjectInterface)]
    internal interface Project : IProject
    {
    }

    [ComImport]
    [Guid(ApiGuids.ProjectClass)]
    internal class ProjectClass
    {
    }

    [ComImport]
    [CoClass(typeof(ModelClass))]
    [Guid(ApiGuids.ModelInterface)]
    internal interface Model : IModel
    {
    }

    [ComImport]
    [Guid(ApiGuids.ModelClass)]
    internal class ModelClass
    {
    }

    [ComImport]
    [CoClass(typeof(EntityClass))]
    [Guid(ApiGuids.EntityInterface)]
    internal interface Entity : IEntity
    {
    }

    [ComImport]
    [Guid(ApiGuids.EntityClass)]
    internal class EntityClass
    {
    }

    [ComImport]
    [CoClass(typeof(DomainClass))]
    [Guid(ApiGuids.DomainInterface)]
    internal interface Domain : IDomain
    {
    }

    [ComImport]
    [Guid(ApiGuids.DomainClass)]
    internal class DomainClass
    {
    }

    [ComImport]
    [CoClass(typeof(DictionaryClass))]
    [Guid(ApiGuids.DictionaryInterface)]
    internal interface Dictionary : IDictionary
    {
    }

    [ComImport]
    [Guid(ApiGuids.DictionaryClass)]
    internal class DictionaryClass
    {
    }

    [ComImport]
    [CoClass(typeof(DiagramClass))]
    [Guid(ApiGuids.DiagramInterface)]
    internal interface Diagram : IDiagram
    {
    }

    [ComImport]
    [Guid(ApiGuids.DiagramClass)]
    internal class DiagramClass
    {
    }

    [ComImport]
    [CoClass(typeof(AttributeClass))]
    [Guid(ApiGuids.AttributeInterface)]
    internal interface Attribute : IAttribute
    {
    }

    [ComImport]
    [Guid(ApiGuids.AttributeClass)]
    internal class AttributeClass
    {
    }
}
