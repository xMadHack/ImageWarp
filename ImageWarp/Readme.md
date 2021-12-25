# Readme

## Roadmap

1. Fixed Pipepline with fixed parameters
2. DDS export built-in support. (https://github.com/microsoft/DirectXTex)
3. Multiple Fixed pipeline, with fixed parameters
4. Configurable pipeline parameters.
5. Configurable pipelines.
6. Built-in texture editor (A la Outfitstudio&Blender) to paint the texture on the model to repair seams.

## Dev notes.

Patching seams is far from perfect. And it also blurs parts where there are no visible seams
(like legs-pelvic veins.). Increasing the size of the mask to fix some seams (for example, the one 
between the glutes) would result in a more blurry image (at least near the seams).
Two ideas to solve that (one doesnt excludes the other):
1. Make a post step: like CBBE Heuristics steps, that fixes cases specifics to this warp model.
2. It might possible to manually fix the warp image. Although it is really difficult to see changes.
I might think of an intermediate image format (BGRA) with visual clues that show better what is going on
when manually moditying one warp image.
And alternatively, making a tool to manually fix this:
 The tool loads a preview of the image. The user draw shapes that cover the imperfection, plus a sample gradient 
 (Or just a shape and it interpolates automatically from bounds, skipping black rectangles)
 All the are covered is replaced with the new generated gradient values. In theory, for this to work,
 it is needed that the shape contain at least 3 good pixels, which should deliver a min-max for both UV colors
 (for example, one pixel at the topleft of the rectangle which is good (no wound), one good pixel at top right,
 and one good at bottomright. The bouning uvs colors can be calculated from there)
 