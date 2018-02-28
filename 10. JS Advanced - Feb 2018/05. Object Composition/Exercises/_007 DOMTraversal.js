function domTraversal(selector) {
    let targetNode = $(selector);
    let maxDepth = 0;
    let deepestNode = targetNode;

    depthFirstSearch(0, targetNode);
    hightFromBottomToTargetNode(maxDepth, deepestNode);

    function hightFromBottomToTargetNode(remainingNodes, currentNode) {
        if (remainingNodes === -1) {
            return;
        }

        currentNode.addClass('highlight');
        let parent = currentNode.parent();
        hightFromBottomToTargetNode(remainingNodes - 1, $(parent));
    }

    function depthFirstSearch(depth, currentNode) {
        if (depth > maxDepth) {
            maxDepth = depth;
            deepestNode = currentNode;
        }

        let children = currentNode.children();
        for (let child of children) {
            depthFirstSearch(depth + 1, $(child));
        }
    }
}

domTraversal('.article');