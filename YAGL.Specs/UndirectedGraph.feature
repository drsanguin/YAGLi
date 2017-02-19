Feature: UndirectedGraph

Scenario: Create a undirected graph who disallow loops and parallel edges
	Given the property disallow loops 
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v0   | v1   |
	| e2   | v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name |
	| e0   |

Scenario: Create a undirected graph who disallow loops and allow parallel edges
	Given the property disallow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v0   | v1   |
	| e2   | v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name |
	| e0   |
	| e1   |

Scenario: Create a undirected graph who allow loops and disallow parallel edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v0   | v1   |
	| e2   | v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name |
	| e0   |
	| e2   |

Scenario: Create a undirected graph who allow loops and parallel edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v0   | v1   |
	| e2   | v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| Name |
	| e0   |
	| e1   |
	| e2   |