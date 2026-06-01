shader_type canvas_item;

uniform vec4 outline_color : source_color = vec4(0.0, 0.0, 0.0, 1.0);
uniform int outline_width : hint_range(1, 10) = 1;

void fragment() {
    vec2 tex_size = vec2(textureSize(TEXTURE, 0));
    vec2 pixel = UV * tex_size;

    bool is_border =
        pixel.x < float(outline_width) ||
        pixel.y < float(outline_width) ||
        pixel.x >= tex_size.x - float(outline_width) ||
        pixel.y >= tex_size.y - float(outline_width);

    if (is_border) {
        COLOR = outline_color;
		//COLOR = texture(TEXTURE, UV);
    } else {
        COLOR = texture(TEXTURE, UV);
    }
}
