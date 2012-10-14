﻿// -----------------------------------------------------------------------
// <copyright file="ITriangle.cs" company="">
// Triangle.NET code by Christian Woltering, http://triangle.codeplex.com/
// </copyright>
// -----------------------------------------------------------------------

namespace TriangleNet.Geometry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TriangleNet.Data;

    /// <summary>
    /// Triangle interface.
    /// </summary>
    public interface ITriangle
    {
        /// <summary>
        /// The triangle id.
        /// </summary>
        int ID { get; }

        /// <summary>
        /// First vertex id of the triangle.
        /// </summary>
        int P0 { get; }
        /// <summary>
        /// Second vertex id of the triangle.
        /// </summary>
        int P1 { get; }
        /// <summary>
        /// Third vertex id of the triangle.
        /// </summary>
        int P2 { get; }

        /// <summary>
        /// Gets a triangles vertex.
        /// </summary>
        /// <param name="index">The vertex index (0, 1 or 2).</param>
        /// <returns>The vertex of the specified corner index.</returns>
        Vertex GetVertex(int index);

        /// <summary>
        /// True if the triangle implementation contains neighbor information.
        /// </summary>
        bool SupportsNeighbors { get; }

        /// <summary>
        /// First neighbor.
        /// </summary>
        int N0 { get; }
        /// <summary>
        /// Second neighbor.
        /// </summary>
        int N1 { get; }
        /// <summary>
        /// Third neighbor.
        /// </summary>
        int N2 { get; }

        /// <summary>
        /// Gets a triangles neighbor.
        /// </summary>
        /// <param name="index">The neighbor index (0, 1 or 2).</param>
        /// <returns>The triangles' neigbbor.</returns>
        ITriangle GetNeighbor(int index);

        /// <summary>
        /// Triangle area constraint.
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Triangle atributes.
        /// </summary>
        double[] Attributes { get; }
    }
}