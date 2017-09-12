using BLL.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IRentalService
    {
        //C
        RentalBO Add(RentalBO video);
        //R
        List<RentalBO> GetAll();
        RentalBO Get(int Id);
        List<RentalBO> Filter(String filter);
        int GetCount();
        //U
        RentalBO Update(RentalBO video);
        //D
        RentalBO Delete(int Id);
    }
}
