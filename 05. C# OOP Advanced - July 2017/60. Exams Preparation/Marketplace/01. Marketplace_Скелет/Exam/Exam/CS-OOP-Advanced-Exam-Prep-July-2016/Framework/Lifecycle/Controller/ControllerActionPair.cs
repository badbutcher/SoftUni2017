namespace CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class ControllerActionPair
    {
        private readonly MethodInfo action;

        /// <summary>
        /// The controller object with all of its
        /// dependencies bundled
        /// </summary>
        private readonly Object controller;

        /// <summary>
        /// Association by position in the input string
        ///     e.g.: /users/{4}/edit/{gosho}
        ///     Arguments are on indices 2 and 4
        /// </summary>
        private IDictionary<int, Type> argumentsMapping;

        public ControllerActionPair(Object controller, MethodInfo action, IDictionary<int, Type> argumentsMapping)
        {
            this.controller = controller;
            this.action = action;
            this.argumentsMapping = argumentsMapping;
        }

        public MethodInfo Action
        {
            get { return this.action; }
        }

        public object Controller
        {
            get { return this.controller; }
        }

        public IDictionary<int, Type> ArgumentsMapping
        {
            get { return this.argumentsMapping; }
        }
    }
}
