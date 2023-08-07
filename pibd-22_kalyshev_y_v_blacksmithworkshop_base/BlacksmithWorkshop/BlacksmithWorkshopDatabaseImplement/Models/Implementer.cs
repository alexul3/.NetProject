using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Implementer : IImplementerModel
    {
        [DataMember]
        public int Id { get; private set; }
		[Required]
        [DataMember]
        public string ImplementerFIO { get; private set; } = string.Empty;
		[Required]
        [DataMember]
        public string Password { get; private set; } = string.Empty;
		[Required]
        [DataMember]
        public int WorkExperience { get; private set; }
		[Required]
        [DataMember]
        public int Qualification { get; private set; }
		[ForeignKey("ImplementerId")]
		public virtual List<Order> Orders { get; set; } = new();
		public static Implementer? Create(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Implementer()
			{
				Id = model.Id,
				ImplementerFIO = model.ImplementerFIO,
				Password = model.Password,
				WorkExperience = model.WorkExperience,
				Qualification = model.Qualification,
			};
		}
		public void Update(ImplementerBindingModel model)
		{
			ImplementerFIO = model.ImplementerFIO;
			Password = model.Password;
			WorkExperience = model.WorkExperience;
			Qualification = model.Qualification;
		}
		public ImplementerViewModel GetViewModel => new()
		{
			Id = Id,
			ImplementerFIO = ImplementerFIO,
			Password = Password,
			WorkExperience = WorkExperience,
			Qualification = Qualification,
		};
	}
}
