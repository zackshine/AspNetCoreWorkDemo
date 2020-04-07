﻿var gulp = require("gulp"),
    cleanCss = require("gulp-clean-css"),
    less = require("gulp-less");

gulp.task("default", function () {
    return gulp.src('wwwroot/Styles/*.less')
        .pipe(less())
        .pipe(cleanCss({ compatibility: 'ie8' }))
        .pipe(gulp.dest('wwwroot/css'));
});