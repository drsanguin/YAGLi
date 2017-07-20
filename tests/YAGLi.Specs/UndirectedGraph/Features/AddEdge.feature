Feature: Adding edge(s), but not the vertices, to a undirected graph

Scenario: Add a IEnumerable of Edges containing loop to a undirected graph who disallow loops
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following IEnumerable of edges to the undirected graph
    | End1 | End2 |
	| v0   | v0   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add a array of Edges containing loop to a undirected graph who disallow loops
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following array of edges to the undirected graph
    | End1 | End2 |
	| v0   | v0   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following array of edges to the undirected graph
    | End1 | End2 |
	| v0   | v0   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add a IEnumerable of Edges containing a parallel edge to a undirected graph who disallow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I add the following IEnumerable of edges to the undirected graph
    | End1 | End2 |
	| v3   | v4   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |

Scenario: Add a array of Edges containing a parallel edge to a undirected graph who disallow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I add the following array of edges to the undirected graph
    | End1 | End2 |
	| v3   | v4   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |

Scenario: Add a IEnumerable of Edges containing a loop to a undirected graph
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following IEnumerable of edges to the undirected graph
    | End1 | End2 |
	| v0   | v0   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v0   |

Scenario: Add a array of Edges containing a loop to a undirected graph
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following array of edges to the undirected graph
    | End1 | End2 |
	| v0   | v0   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v0   |

Scenario: Add a IEnumerable of Edges containing a parallel edge to a undirected graph
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I add the following IEnumerable of edges to the undirected graph
    | End1 | End2 |
	| v3   | v4   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add a array of Edges containing a parallel edge to a undirected graph
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I add the following array of edges to the undirected graph
    | End1 | End2 |
	| v3   | v4   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add an edge to a undirected graph who allow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edge to the undirected graph
    | End1 | End2 |
	| v0   | v2   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v2   |

Scenario: Add an edge to a undirected graph who disallow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I add the edge to the undirected graph
    | End1 | End2 |
	| v0   | v2   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v0   | v2   |

Scenario: Add a IEnumerable of Edges to a undirected graph who allow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following IEnumerable of edges to the undirected graph
	| End1 | End2 |
	| v0   | v2   |
	| v1   | v2   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v2   |
	| v1   | v2   |

Scenario: Add a array of Edges to a undirected graph who allow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following array of edges to the undirected graph
	| End1 | End2 |
	| v0   | v2   |
	| v1   | v2   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v2   |
	| v1   | v2   |

Scenario: Add a IEnumerable of Edges to a undirected graph who disallow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I add the following IEnumerable of edges to the undirected graph
	| End1 | End2 |
	| v0   | v2   |
	| v1   | v2   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v0   | v2   |
	| v1   | v2   |

Scenario: Add a array of Edges to a undirected graph who disallow parallel edges
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I add the following array of edges to the undirected graph
	| End1 | End2 |
	| v0   | v2   |
	| v1   | v2   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v0   | v2   |
	| v1   | v2   |

Scenario: Add an edge whose vertices who are not already contained in a undirected graph
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
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edge to the undirected graph
    | End1 | End2 |
	| v5   | v6   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |