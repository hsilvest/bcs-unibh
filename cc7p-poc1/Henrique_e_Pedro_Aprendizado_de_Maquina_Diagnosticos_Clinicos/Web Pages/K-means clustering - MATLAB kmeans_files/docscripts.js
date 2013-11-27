// Toggle a division as expanded or collapsed.
// Also toggle the arrow icon.
// Refer to the division and image by their IDs.
//
// "Collapsed" material is hidden using the
// display property in CSS.

// Used by adaptproduct function (see below)
// to support adaptive doc in the Windows
// version of the Help Browser.
var adaptiveIds = new Array();
function toggleexpander(blockid, arrowid) {
    arrow = document.getElementById(arrowid);
    block = document.getElementById(blockid);
    if (block.style.display == "none") {
        // Currently collapsed, so expand it.
        block.style.display = "block";
        arrow.src = "arrow_down.gif";
        arrow.alt = "Click to Collapse";
    }
    else {
        // Currently expanded, so collapse it.
        block.style.display = "none";
        arrow.src = "arrow_right.gif";
        arrow.alt = "Click to Expand";
    }
    return false; // Make browser ignore href.
}

// ===================================================
// Create and uniquely name two levels of upward navigation buttons
// for Functions -- By Category pages

var top_button_count = 0;
var current_section_id = 0;

function addTopOfPageButtons() {

    top_button_count = top_button_count + 1;

    var top_of_page_buttons =

        "<a class=\"pagenavimglink\" href=\"#top_of_page\" onMouseOver=\"document.images.uparrow" +
            top_button_count +
            ".src=\'doc_to_top_down.gif\'\;\" onMouseOut=\"document.images.uparrow" +
            top_button_count +
            ".src=\'doc_to_top_up.gif\'\;\"><img style=\"margin-top:0;margin-bottom:0px;padding-top:0;padding-bottom:0\" border=0 src=\"doc_to_top_up.gif\"  alt=\"Back to Top of Page\" title=\"Back to Top of Page\" name=\"uparrow" +
            top_button_count +
            "\">\&nbsp\;</a>";

    document.write(top_of_page_buttons);
}


function updateSectionId(id) {
    current_section_id = id;
}


function addTopOfSectionButtons() {

    top_button_count = top_button_count + 1;

    var top_of_page_buttons =

        "<a class=\"pagenavimglink\" href=" +
            "\"#" + current_section_id + "\"" +
            " onMouseOver=\"document.images.uparrow" +
            top_button_count +
            ".src=\'doc_to_section_down.gif\'\;\" onMouseOut=\"document.images.uparrow" +
            top_button_count +
            ".src=\'doc_to_section_up.gif\'\;\"><img style=\"margin-top:0;margin-bottom:0px;padding-top:0;padding-bottom:0\" border=0 src=\"doc_to_section_up.gif\"  alt=\"Back to Top of Section\" title=\"Back to Top of Section\" name=\"uparrow" +
            top_button_count +
            "\">\&nbsp\;</a>";

    document.write(top_of_page_buttons);
}

// ===================================================
// Create and write to the document stream HTML for 
// the link to the Doc Feedback Survey site.
//
// Doing this through a JavaScript function is necessary
// to work around the an issue with pages that are found
// through the search facility of the help browser--
//
// When found as the result of a search, 
// the document that is displayed in the Help browser
// is actually a temporary document with a trivial URL
// such as "text://5", not an actual page location.
//
// But the Help browser inserts a <BASE> element at the beginning
// of each such temporary page, and the <BASE> element stores the
// actual location. 
//
// So this function tests the URL of the document for the expression "text://"
// and if that expression is found, attempts to use the URL stored in
// the <BASE> element.

function writeDocFeedbackSurveyLink() {
    var queryexpression = document.location.href;
    var istempsearchpage = false;

    if (queryexpression.indexOf("help/ja_JP/") >= 0) {
        // Japanese
        str_yes = "&#x306f;&#x3044;";
        str_no = "&#x3044;&#x3044;&#x3048;";
        str_helpful = "<span style=\"font-size:1.2em\">&#x3053;&#x306e;&#x60c5;&#x5831;&#x306f;&#x5f79;&#x306b;&#x7acb;&#x3061;&#x307e;&#x3057;&#x305f;&#x304b;&#xff1f;</span>";
    }
    else if (queryexpression.indexOf("help/zh_CN/") >= 0) {
        // Chinese
        str_yes = "&#x662F;";
        str_no = "&#x5426;";
        str_helpful = "<span style=\"font-size:1.2em\">&#x8FD9;&#x91CC;&#x7684;&#x8BAE;&#x9898;&#x5BF9;&#x4F60;&#x6709;&#x5E2E;&#x52A9;&#x5417;&#xFF1F;</span>";
    }
    else {
        // Default to English
        str_yes = "Yes";
        str_no = "No";
        str_helpful = "Was this topic helpful?";
    }
    ;

    if (queryexpression.search(/text:\/\//) != -1) {
        var baseelement = document.getElementsByTagName("BASE")[0];
        queryexpression = baseelement.href;
    }
    survey_url_yes = "http://www.customersat3.com/TakeSurvey.asp?si=YU2FDmNEifg%3D&SF=" + queryexpression + "-YES";
    survey_url_no = "http://www.customersat3.com/TakeSurvey.asp?si=YU2FDmNEifg%3D&SF=" + queryexpression + "-NO";

    code = '<div style="padding-right:10px" class="feedbackblock">' + '<strong>' + str_helpful + '</strong> <input type="button" value="' + str_yes + '" onClick="openWindow(\'' + survey_url_yes + '\',850,680, \'scrollbars=yes,resizable=yes\'); return false;"/>' + '&nbsp;&nbsp;' + '<input type="button" value="' + str_no + '" onClick="openWindow(\'' + survey_url_no + '\',850,680, \'scrollbars=yes,resizable=yes\'); return false;"/>' + '</div>';
    document.write(code);
}


// Utility function replacing openWindow function used by the web-site survey link code.
// In the help browser, the original code would create a blank window before loading the URL into the system browser.
function openWindow(url, width, height, options, name) {
    // ignore the arguments, except url
    document.location = url;
} // end function openWindow


// Utility function for linking to feedback survey, as of R2012b.
function openFeedbackWindow(url) {
    window.open(url,"_blank");
} // end function openFeedbackWindow



// ===================================================
// Workaround for G801125.
// This global object check tests for IE8 or lower.
if (document.all && !document.getElementsByClassName) {
    document.createElement("section");
}



// ===================================================
// Function reference pages

$(window).load(function () {
    // Perform breadcrumb check in window load, since all the images in the breadcrumb
    // need to be loaded for correct width calculations.
    getBreadcrumb().mwBreadcrumb();
    expandCollapsedContent();
});

$(document).ready(function () {
    if (getParameterByName("browser") === "F1help") {
        $('.toc_pane').hide();
        $('.docsearch_container').hide();
        $('.breadcrumb_container').hide();
        $("#doc_center_content").on('mouseenter', 'a', function() {
            if ($(this).attr('href').indexOf("matlab:") === 0) {
                return;
            }
            if ($(this).hasClass('corrected_url')) {
                return;
            }
            $(this).addClass('corrected_url');
            $(this).attr('href', function (i, h) {
                if (h === undefined) {
                    return "";
                }
                var srcUrl, hash, hashIndex;
                if (h.indexOf('#') > 0) {
                    hashIndex = h.indexOf('#');
                    hash = h.substring(hashIndex, h.length);
                } else {
                    hash = '';
                    hashIndex = h.length;
                }

                srcUrl = h.substring(0, hashIndex);
                return srcUrl + (srcUrl.indexOf('?') != -1 ? "&browser=F1help" : "?browser=F1help") + hash;
            });
        });
    } else {
        $('div.toc_container_wrapper').setupToc();
    }

    //Perform JS code which has any user visible impact first.
    //Check image sizes. Do not scale animated images or any images with hotspots.


    $('#doc_center_content img:not(".animated-image, [usemap]"), #content_container2 img:not(".animated-image, [usemap]")').scaleImage();
    $('#doc_center_content img.animated-image, #content_container2 img.animated-image').animateImage();

    // Work around for crashes on Win64 machines.
    $('#content_container a').not('[href="#"], [href="javascript:void(0);"], .intrnllnk')
        .click(function() {
            var href = $(this).attr('href');
            setTimeout(function() {
                window.location = href;
            }, 50);
            return false;
        });

    addSmoothScroll();
    $('.expandAllLink').click(function(e) {
        e.stopPropagation();
        var link = $(this);
        if (link.data('allexpanded')) {
            doCollapse(link);
            link.data('allexpanded', false);
            link.html('expand all');
        } else {
            doExpand(link);
            link.data('allexpanded', true);
            link.html('collapse all');
        }
    });

    $("#content_container").delegate(".expand", "click", function(e) {
        e.stopPropagation();
        doToggle($(this));
        return false;
    });

    $('#expand_page').click(function () {
        var link = $(this).find('a');
        if (link.data('allexpanded')) {
            doCollapse($('.collapse'));
            link.data('allexpanded', false);
            link.html('expand all');
        } else {
            doExpand($('.collapse'));
            link.data('allexpanded', true);
            link.html('collapse all');
        }
    });
    applySearchHighlight();
});

function applySearchHighlight() {
    if ($.fn.highlight) {
        var highlighterCSSClass = ['highlight_01', 'highlight_02'];
        var searchHighlightTerm = getParameterByName('searchHighlight');
        if (searchHighlightTerm.length > 0) {
            var searchHighlightArray = getParameterByName('searchHighlight').match(/\w+|"[^"]+"/g);
            $.each(searchHighlightArray, function (index, value) {
                var searchTerm = value.replace(/^"|"$/g, '');
                var cssClass = highlighterCSSClass[index % highlighterCSSClass.length];
                $("#doc_center_content").highlight(searchTerm,
                    {className:cssClass, wordsOnly: true});
                var elements = $("#doc_center_content").find("." + cssClass);

                setTimeout(function() {
                    expandHighlightedElements(elements);
                }, 50);
            });

            $(document).keyup(function (e) {
                if (e.which === 27) {
                    var classArray = $.map(highlighterCSSClass, function(value) {
                        return "." + value;
                    });
                    var highlightedEl = $(classArray.join(","));
                    $.each(highlightedEl, function() {
                        $(this).removeClass();
                    });
                }
            });
        }
    }
}

function expandHighlightedElements(elements) {
    $.each(elements, function() {
        if (!$(this).is(":visible")) {
            var collapsedParent = $(this).closest('.collapse').prev();
            if (collapsedParent.length > 0) {
                prepareEltForExpansion(collapsedParent, true);
                if (collapsedParent.hasClass('expand') &&
                    !collapsedParent.hasClass('expanded')) {
                    doToggle(collapsedParent, true);
                }
            }
        }
    });
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS, 'g');
    var results;
    var value = "";
    while (true) {
        results = regex.exec(window.location.href);
        if (results == null) {
            break;
        }
        value = decodeURIComponent(results[1].replace(/\+/g, " "));
    }
    return value;
}


//helper method to fetch the breadcrumb.
function getBreadcrumb() {
    var breadcrumb;
    if ($("#breadcrumbs").length != 0) {
        breadcrumb = $("#breadcrumbs");
    } else {
        breadcrumb = $(".breadcrumbs:first");
    }
    return breadcrumb;
}

function expandCollapsedContent() {
    if (location.hash.length > 0) {
        var target = getInternalLinkTarget(location.hash);
        if (target) {
            var nextSibling = getNextSiblingForAnchorTarget(target);
            prepareEltForExpansion(nextSibling);
            if (nextSibling.hasClass('expand') && !nextSibling.hasClass('expanded')) {
                doToggle(nextSibling);
                nextSibling.addClass('anchor_hinting');
                setTimeout(function () {
                    nextSibling.removeClass('anchor_hinting');
                }, 600);
            }
        }
    }
}

function prepareEltForExpansion(elt, noAnimation) {
    if (elt.hasClass('expand')) {
        doExpandNestedParent(elt, noAnimation);
    } else if (!elt.is(":visible")) {
        doExpandParent(elt, noAnimation);
    }
}

function getNextSiblingForAnchorTarget(target) {
    var nextSibling;
    if (target.is('a')) {
        nextSibling = target.next();
    } else {
        //This needs to be cleaned up.
        //We need to make sure all anchor targets are anchor tags themselves.
        //
        if (target.children().length > 0) {
            nextSibling = target.children(":first");
        } else {
            nextSibling = target;
        }
    }
    return nextSibling;
}

function addSmoothScroll() {
    $(".intrnllnk").each(function() {
        var hash = this.hash;
        var target = getInternalLinkTarget(hash);
        if (target) {
            $(this).click(function (evt) {
                evt.preventDefault();
                var nextSibling = getNextSiblingForAnchorTarget(target);
                prepareEltForExpansion(nextSibling);

                //On IE and FF, the slow scroll parameter is the HTML dom element. On webkit, it is the body.
                var scrollParameter = ($.browser.msie || $.browser.mozilla) ? 'html' : 'body';
                $(scrollParameter).animate({scrollTop:target.offset().top - 10}, 700, function () {
                    nextSibling.addClass('anchor_hinting');
                    setTimeout(function () {
                        nextSibling.removeClass('anchor_hinting');
                    }, 600);
                    if (nextSibling.hasClass('expand')) {
                        doExpand(nextSibling);
                    }
                });
                location.hash = hash;
            })
        }
    });
}

function getInternalLinkTarget(hash) {
    //search for anchor with given hash as "name" atrribute value;
    var target = null;

    //Remove the first '#' character from the name attribute. Escape any special character from the name/id.
    var escapedHash = hash.substring(1).replace(/([;&,.+*~':"!^#$%@\[\]\(\)=>\|])/g, '\\$1');

    target = $('[name=' + escapedHash + ']');
    //If no target is found, try to find an element whose id has value = hash.
    if (target.length === 0) {
        target = $(hash);
    }
    return target;
}

function findExpandableContent(elt) {
    if (!elt.hasClass('expandableContent')) {
        elt = elt.closest('.expandableContent');
    }
    return elt;
}

function doExpand(elt, noAnimation) {
    var expandable = findExpandableContent(elt);
     if (($.browser.msie && $.browser.version <= 8) || noAnimation) {
        expandable.find('.collapse').show();
        expandable.find('.expand').addClass('expanded');
        checkExpandAllLinkState(elt);
        return;
    }

    expandable.find('.collapse').slideDown(function () {
        expandable.find('.expand').addClass('expanded');
        checkExpandAllLinkState(elt);
    });
}

function doCollapse(elt, noAnimation) {
    var expandable = findExpandableContent(elt);
    //Before collapsing, check if the collapse child has any expandableContent children.
    //If it does, those divs need to be collapsed and not the parent.
    if (expandable.find('.collapse').children('.expandableContent').length > 0) {
        expandable = expandable.find('.collapse').children('.expandableContent');
    }

    if (($.browser.msie && $.browser.version <= 8) || noAnimation) {
        expandable.find('.collapse').hide();
        expandable.find('.expand').removeClass('expanded');
        checkExpandAllLinkState(elt);
        return;
    }

    expandable.find('.collapse').slideUp(function () {
        expandable.find('.expand').removeClass('expanded');
        checkExpandAllLinkState(elt);
    });
}

function doToggle(elt, noAnimation) {
    var expandable = findExpandableContent(elt);
    if (($.browser.msie && $.browser.version <= 8) || noAnimation) {
        expandable.children('.collapse').toggle();
        expandable.children('.expand').toggleClass('expanded');
        checkExpandAllLinkState(elt);
        return;
    }

    expandable.children('.collapse').slideToggle(function () {
        expandable.children('.expand').toggleClass('expanded');
        checkExpandAllLinkState(elt);
    });
}

function checkExpandAllLinkState(elt) {
    //Check if the expandable elt is nested within another expandable elt.
    var expandableParent = elt.parents('.expandableContent:eq(1)');

    // If element is not nested, or there is not expand all link, return
    if (expandableParent.length === 0 || expandableParent.find('.expandAllLink').length === 0) {
        return;
    }
    var expandAllLink = expandableParent.find('.expandAllLink:first');
    var expandableChildren = expandableParent.find('.expandableContent');


    if (elt.hasClass('expanded')) {
        var allChildrenExpanded = true;
        expandableChildren.each(function() {
            var expand = $(this).find('.expand');
            if (!expand.hasClass("expanded")) {
                allChildrenExpanded = false;
            }
        });
        if (allChildrenExpanded) {
            expandAllLink.data('allexpanded', true);
            expandAllLink.html("collapse all");
        }
    } else {
        var allChildrenCollapsed = true;
        expandableChildren.each(function() {
            var expand = $(this).find('.expand');
            if (expand.hasClass("expanded")) {
                allChildrenCollapsed = false;
            }
        });

        if (allChildrenCollapsed) {
            expandAllLink.data('allexpanded', false);
            expandAllLink.html("expand all");
        }
    }
}

function doExpandNestedParent(elt, noAnimation) {
    var expandable = findExpandableContent(elt);
    var expandableParent = expandable.parent().siblings('.expand');
    if (expandableParent.length > 0) {
        if (!expandableParent.hasClass('expanded')) {
            doToggle(expandableParent, noAnimation);
        }
    }
}

// This method is used to support the old HTML template for the ref pages. When all the ref pages have been
// converted to the new template, consolidate this method with the doExpandNestedParent method above.
function doExpandParent(elt, noAnimation) {
    var expandable = elt.closest('.collapse');
    var expandableParent = expandable.siblings('.expand');
    if (expandableParent.length > 0) {
        if (!expandableParent.hasClass('expanded')) {
            doToggle(expandableParent, noAnimation);
        }
    }
}

// Copyright 2002-2012 The MathWorks, Inc.
