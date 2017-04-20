Feature: UndirectedGraphModification

Scenario: Add a loop to a undirected graph who disallow loops
	Given the property disallow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the edges
    | Name | End1 | End2 |
	| e5   | v0   | v0   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |

Scenario: Add a parallel edge to a undirected graph who disallow parallel edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	And the undirected graph created with them
	When I add the edges
    | Name | End1 | End2 |
	| e4   | v3   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |

Scenario: Add a loop to a undirected graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the edges
    | Name | End1 | End2 |
	| e5   | v0   | v0   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |
	| e5   |

Scenario: Add a parallel edge to a undirected graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	And the undirected graph created with them
	When I add the edges
    | Name | End1 | End2 |
	| e4   | v3   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |

Scenario: Add a edge to a undirected graph
Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the edge "e5" with the ends "v0" and "v2"
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |
	| e5   |

Scenario: Add edges to a undirected graph
Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the edges
	| Name | End1 | End2 |
	| e5   | v0   | v2   |
	| e6   | v1   | v2   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |
	| e5   |
	| e6   |

Scenario: Add a edge with vertices who are not already contained in a undirected graph
Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the edge "e5" with the ends "v5" and "v6"
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |

Scenario: Add a vertex to a undirected graph
Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the vertex "v5"
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |

Scenario: Add vertices to a undirected graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the vertices
    | Name |
	| v5   |
	| v6   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	| v6   |
	And this new undirected graph should contains the edges
    | Name |
	| e0   |
	| e1   |
	| e3   |
	| e4   |

Scenario: Add edge and vertices to a undirected graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the edge "e5" with the vertices "v5" and "v6"
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	| v6   |
	And this new undirected graph should contains the edges
    | Name |
    | e0   |
    | e1   |
    | e3   |
    | e4   |
    | e5   |

Scenario: Add edges and vertices to a undirected graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
    | Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	And the undirected graph created with them
	When I add the edges and vertices
    | Name | End1 | End2 |
	| e5   | v5   | v6   |
	| e6   | v0   | v7   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	| v6   |
	| v7   |
	And this new undirected graph should contains the edges
    | Name |
    | e0   |
    | e1   |
    | e3   |
    | e4   |
    | e5   |
	| e6   |