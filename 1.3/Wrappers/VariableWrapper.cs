/* Reflexil Copyright (c) 2007-2011 Sebastien LEBRETON

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */

#region " Imports "
using Mono.Cecil;
using Mono.Cecil.Cil;
#endregion

namespace Reflexil.Wrappers
{
	/// <summary>
	/// Variable wrapper
	/// </summary>
	public partial class VariableWrapper : IWrapper<VariableDefinition>
	{
		
		#region " Fields "
		private MethodDefinition m_mdef;
		private VariableDefinition m_variable;
		#endregion
		
		#region " Properties "
        public VariableDefinition Item
		{
			get
			{
				return m_variable;
			}
			set
			{
				m_variable = value;
			}
		}
		
		public MethodDefinition MethodDefinition
		{
			get
			{
				return m_mdef;
			}
			set
			{
				m_mdef = value;
			}
		}
		#endregion
		
		#region " Methods "
        /// <summary>
        /// Default constructor
        /// </summary>
		public VariableWrapper()
		{
		}
		
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="variable">Variable to wrap</param>
        /// <param name="mdef">Method definition</param>
		public VariableWrapper(VariableDefinition variable, MethodDefinition mdef)
		{
			m_variable = variable;
			m_mdef = mdef;
		}

        /// <summary>
        /// Returns a String that represents the wrapped instruction
        /// </summary>
        /// <returns>See OperandDisplayHelper.ToString</returns>
		public override string ToString()
		{
			return OperandDisplayHelper.ToString(m_variable);
		}

        /// <summary>
        /// Create an instruction, using the wrapped item as an operand
        /// </summary>
        /// <param name="worker">Cil worker</param>
        /// <param name="opcode">Instruction opcode</param>
        /// <returns></returns>
		public Instruction CreateInstruction(ILProcessor worker, OpCode opcode)
		{
			return worker.Create(opcode, Item);
		}
		#endregion
		
	}
}
