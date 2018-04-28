using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ErrorHandlingExt
{
    #region Result

    /// <summary>
    /// Result structure.
    /// </summary>
    public struct Result
    {
        /// <summary>
        /// Returns if <see cref="Result"/> is successful or not.
        /// </summary>
        public bool IsSuccess { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Exception _error;
        /// <summary>
        /// Returns an <see cref="Exception"/> from failed <see cref="Result"/>.
        /// </summary>
        public Exception Error
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no error for success.");

                return _error;
            }
        }

        [DebuggerStepThrough]
        private Result(bool isSuccess, Exception error = null)
        {
            IsSuccess = isSuccess;
            _error = error;
        }

        /// <summary>
        /// Creates a successful <see cref="Result"/>.
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result FromSuccess()
        {
            return new Result(true);
        }

        /// <summary>
        /// Creates a failed <see cref="Result"/> with given error.
        /// </summary>
        /// <param name="error">The <see cref="Result"/> error.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result FromFailure(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return new Result(false, error);
        }

        /// <summary>
        /// Creates a <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result From(Action action)
        {
            try
            {
                action();

                return FromSuccess();
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result From(Func<Result> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result> FromAsync(Func<Task> func)
        {
            try
            {
                await func().ConfigureAwait(false);

                return FromSuccess();
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result> FromAsync(Func<Task<Result>> func)
        {
            try
            {
                return await func().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result> FromAsync(Action action)
        {
            Result result = From(action);

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Creates a <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result> FromAsync(Func<Result> func)
        {
            Result result = From(func);

            return await Task.FromResult(result);
        }
    }

    #endregion

    #region Result<T>

    /// <summary>
    /// Result&lt;T&gt; structure.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="Value"/> property.</typeparam>
    public struct Result<T>
    {
        /// <summary>
        /// Returns if <see cref="Result{T}"/> is successful or not.
        /// </summary>
        public bool IsSuccess { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;
        /// <summary>
        /// Returns the value of <see cref="Result{T}"/>.
        /// </summary>
        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException("There is no value for failure.");

                return _value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Exception _error;
        /// <summary>
        /// Returns an <see cref="Exception"/> from failed <see cref="Result{T}"/>.
        /// </summary>
        public Exception Error
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no error for success.");

                return _error;
            }
        }

        [DebuggerStepThrough]
        private Result(T value)
        {
            IsSuccess = true;
            _value = value;
            _error = null;
        }

        [DebuggerStepThrough]
        private Result(Exception error)
        {
            IsSuccess = false;
            _value = default(T);
            _error = error;
        }

        /// <summary>
        /// Creates a successful <see cref="Result{T}"/> with given value type.
        /// </summary>
        /// <param name="value">The <see cref="Result{T}.Value"/>.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result<T> FromSuccess(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return new Result<T>(value);
        }

        /// <summary>
        /// Creates a failed <see cref="Result{T}"/> with given error.
        /// </summary>
        /// <param name="error">The <see cref="Result{T}"/> error.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result<T> FromFailure(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return new Result<T>(error);
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result<T> From(Func<T> func)
        {
            try
            {
                T value = func();

                return FromSuccess(value);
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result<T> From(Func<Result<T>> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result<T>> FromAsync(Func<Task<T>> func)
        {
            try
            {
                T value = await func().ConfigureAwait(false);

                return FromSuccess(value);
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result<T>> FromAsync(Func<Task<Result<T>>> func)
        {
            try
            {
                return await func().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result<T>> FromAsync(Func<T> func)
        {
            Result<T> result = From(func);

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result<T>> FromAsync(Func<Result<T>> func)
        {
            Result<T> result = From(func);

            return await Task.FromResult(result);
        }
    }

    #endregion;
}
