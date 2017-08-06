using System;
using System.Threading.Tasks;

namespace ErrorHandlingExt
{
    public struct Result
    {
        public bool IsSuccess { get; }

        private Exception error;
        public Exception Error
        {
            get
            {
                if (this.IsSuccess)
                    throw new InvalidOperationException("There is no error for success");

                return this.error;
            }
        }

        private Result(bool isSuccess, Exception error = null)
        {
            this.IsSuccess = isSuccess;
            this.error = error;
        }

        public static Result FromSuccess()
        {
            return new Result(true);
        }

        public static Result FromFailure(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return new Result(false, error);
        }

        public static Result From(Action action)
        {
            try
            {
                action();
                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        public static async Task<Result> FromAsync(Func<Task> func)
        {
            try
            {
                await func().ConfigureAwait(false);
                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }
    }

    public struct Result<T>
    {
        public bool IsSuccess { get; private set; }

        private readonly T value;
        public T Value
        {
            get
            {
                if (!this.IsSuccess)
                    throw new InvalidOperationException("There is no value for failure.");

                return this.value;
            }
        }

        private readonly Exception error;
        public Exception Error
        {
            get
            {
                if (this.IsSuccess)
                    throw new InvalidOperationException("There is no error for success.");

                return this.error;
            }
        }

        private Result(T value)
        {
            this.IsSuccess = true;
            this.value = value;
            this.error = null;
        }

        private Result(Exception error)
        {
            this.IsSuccess = false;
            this.value = default(T);
            this.error = error;
        }

        public static Result<T> FromSuccess(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return new Result<T>(value);
        }

        public static Result<T> FromFailure(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return new Result<T>(error);
        }

        public static Result<T> From(Func<T> func)
        {
            try
            {
                var value = func();
                return Result<T>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<T>.FromFailure(ex);
            }
        }

        public static async Task<Result<T>> FromAsync(Func<Task<T>> func)
        {
            try
            {
                var value = await func().ConfigureAwait(false);
                return Result<T>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<T>.FromFailure(ex);
            }
        }
    }
}
