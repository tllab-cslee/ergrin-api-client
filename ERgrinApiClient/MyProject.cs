using ERgrin.Api;
using System.Collections.Generic;
using System.Linq;

namespace ERgrinApiClient
{
    internal class MyProject
    {
        //--------------------------------------------------------------------------------
        // Properties
        //--------------------------------------------------------------------------------

        public List<IModel> Models { get; set; }
        public List<IEntity> Entities { get; set; }
        public List<IAttribute> Attributes { get; set; }
        public List<IDomain> Domains { get; set; }

        //--------------------------------------------------------------------------------
        // Public Methods
        //--------------------------------------------------------------------------------

        public bool LoadFile(string filepath)
        {
            Models = null;
            Entities = null;
            Attributes = null;

            project = new Project();
            project.Load(filepath);

            if (project == null)
                return false;

            Models = new List<IModel>();
            for (int i = 0; i < project.ModelCount; i++)
            {
                Models.Add(project.GetModel(i));
            }

            return true;
        }

        public void SaveFile(string filePath = default)
        {
            project?.Apply(filePath);
        }

        public void SetEntities(IModel model, string diagramName)
        {
            Entities = new List<IEntity>();
            int entityCount = model.GetEntityCount(diagramName);
            for (int i = 0; i < entityCount; i++)
            {
                Entities.Add(model.GetEntity(diagramName, i));
            }
        }

        public void SetDomains(IModel model)
        {
            Domains = new List<IDomain>();
            for (int i = 0; i < model.DomainCount; i++)
            {
                Domains.Add(model.GetDomain(i));
            }
        }

        public void SetAttribute(IEntity entity)
        {
            if (entity == null)
            {
                Attributes = null;
                return;
            }

            Attributes = new List<IAttribute>();
            for (int i = 0; i < entity.AttributeCount; i++)
            {
                Attributes.Add(entity.GetAttribute(i));
            }
        }

        public IModel FindModel(string name)
        {
            return Models?.Where(x => name.Equals(x.LogicalName)).FirstOrDefault();
        }

        public IDiagram FindDiagram(IModel model, string name)
        {
            for (int i = 0; i < model.DiagramCount; i++)
            {
                var diagram = model.GetDiagram(i);
                if (diagram.Name == name)
                    return diagram;
            }
            return null;
        }

        public IEntity FindEntity(string name)
        {
            return Entities?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        public IAttribute FindAttribute(string name)
        {
            return Attributes?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        public MyProps GetProps(IEntity entity, IAttribute attribute)
        {
            var props = new MyProps(this);

            props.EntityID = entity?.ID.ToUpper();
            props.EntityLogicalName = entity?.LogicalName;
            props.EntityPhysicalName = entity?.PhysicalName;
            props.EntityDescription = entity?.Description;

            props.AttributeID = attribute?.ID.ToUpper();
            props.AttributeLogicalName = attribute?.LogicalName;
            props.AttributePhysicalName = attribute?.PhysicalName;
            props.AttributeDescription = attribute?.Description;
            props.AttributeNullable = attribute?.Nullable;
            props.AttributeDomainName = attribute?.DomainName;
            props.AttributeDataType = attribute?.DataType;

            return props;
        }

        //--------------------------------------------------------------------------------
        // Private Fields
        //--------------------------------------------------------------------------------

        private Project project;
    }
}
