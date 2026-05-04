using CMS_ClassLibrary.Models;
using Dapper;
using System.Data;

namespace CMS_ClassLibrary.DataAccess;

public class DapperTypeHandlers
{




    public class CarGearboxTypeHandler : SqlMapper.TypeHandler<CarGearboxType>
    {
        public override void SetValue(IDbDataParameter parameter, CarGearboxType value)
        {
            parameter.Value = value.ToString();
        }

        public override CarGearboxType Parse(object value)
        {
            return Enum.Parse<CarGearboxType>(value.ToString()!);
        }
    }



    public class CarBodyTypeHandler : SqlMapper.TypeHandler<CarBodyType>
    {
        public override void SetValue(IDbDataParameter parameter, CarBodyType value)
        {
            parameter.Value = value.ToString();
        }

        public override CarBodyType Parse(object value)
        {
            return Enum.Parse<CarBodyType>(value.ToString()!);
        }
    }

    public class CarFuelTypeHandler : SqlMapper.TypeHandler<CarFuelType>
    {
        public override void SetValue(IDbDataParameter parameter, CarFuelType value)
        {
            parameter.Value = value.ToString();
        }

        public override CarFuelType Parse(object value)
        {
            return Enum.Parse<CarFuelType>(value.ToString()!);
        }
    }
}
