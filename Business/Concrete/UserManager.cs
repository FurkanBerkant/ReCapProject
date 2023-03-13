using Business.Abstract;
using Business.Constants;
using Core.Entites;
using Core.Utilites.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>
                (_userDal.GetAll().ToList());
        }

        public IResult GetById(int id)
        {
            _userDal.Get(c => c.Id == id);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
