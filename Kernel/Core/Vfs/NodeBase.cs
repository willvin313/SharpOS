//
// (C) 2006-2008 The SharpOS Project Team (http://www.sharpos.org)
//
// Authors:
//	Michael Ruck (aka grover) <sharpos@michaelruck.de>
//
// Licensed under the terms of the GNU GPL v3,
//  with Classpath Linking Exception for Libraries
//

using System;
using System.IO;

namespace SharpOS.Kernel.Vfs {
	/// <summary>
	/// Provides a default implementation for INodes. A filesystem implementation
	/// may choose to derive from BasicNode to receive a default implementation of
	/// the interface.
	/// </summary>
	public abstract class NodeBase : IVfsNode {

		#region Data members

        /// <summary>
        /// Holds the filesystem of the node.
        /// </summary>
        private IFileSystem _fs;

		/// <summary>
		/// Holds the type of the IVfsNode represented by this instance.
		/// </summary>
		private VfsNodeType _type;

		#endregion // Data members

		#region Construction

		protected NodeBase(IFileSystem fs, VfsNodeType type)
		{
            _fs = fs;
            _type = type;
		}

		#endregion // Construction

		#region IVfsNode members

        public IFileSystem FileSystem { get { return _fs; } }

		public VfsNodeType NodeType { get { return _type; } }

		public abstract IVfsNode Create (char[] name, VfsNodeType type, object settings);

		public virtual IVfsNode Lookup (char[] name)
		{
			return null;
		}

		public abstract object Open(FileAccess access, FileShare sharing);

		public abstract void Delete();

		#endregion // IVfsNode members
	}
}