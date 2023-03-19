using Business.Abstract;
using Business.Constants;
using Core.Entites;
using Core.Entities.Concrete;
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
            var result = UserExists(user.Email);
            if (!result.Success)
                return new ErrorResult(result.Message);

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
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.RentalUpdated);
        }
        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
        private IResult UserExists(string email)
        {
            var user = GetByEmail(email);
            if (user.Data != null)
                return new ErrorResult(Messages.UserExists);
            return new SuccessResult();
        }
    }
}
