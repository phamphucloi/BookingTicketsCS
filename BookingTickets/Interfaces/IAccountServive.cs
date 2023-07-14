﻿using BookingTickets.Models;

namespace BookingTickets.Interfaces;

public interface IAccountServive
{
    public bool Add(Account acc);
    public bool Update(Account acc);
    public bool Delete(int id);
    public dynamic GetById(int id);
    public Account GetById2(int id);
    public dynamic GetAll();
    public bool Login(string email, string password);
    public dynamic GetByEmail(string email);
    public bool CheckEmailExists(string email);

}
